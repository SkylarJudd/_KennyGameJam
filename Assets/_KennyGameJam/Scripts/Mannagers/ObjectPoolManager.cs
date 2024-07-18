using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;


public enum PoolType
{
    GameObject,
    Particales,
    Sounds,
    None,

}

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public List<PooledObjectInfo> objectPools = new List<PooledObjectInfo>();

    #region ObjectPoolEmpites
    [SerializeField] private GameObject _objectPoolEmptyHolder;


    private GameObject _gameObjects;
    private GameObject _particalesEmpty;
    private GameObject _sounds;
    #endregion

    [SerializeField] int minPoolSize = 5;

    [HideInInspector] public PoolType PoolingType;

    

    private void Start()
    {
        SetUpEmpties();
        StartCoroutine(CheckInactiveObjects());
    }

    private void SetUpEmpties()
    {

        #region CreatingObjectPoolEmpties
        if(_objectPoolEmptyHolder == null)
        _objectPoolEmptyHolder = new GameObject("PooledObjects");

        // Initialize these objects before using them


        // Other
        CreateAndParent(ref _gameObjects, _objectPoolEmptyHolder, "ParticalPools");
        CreateAndParent(ref _particalesEmpty, _objectPoolEmptyHolder, "ParticalPools");
        CreateAndParent(ref _sounds, _objectPoolEmptyHolder, "SoundsPools");
        #endregion



    }

    private void CreateAndParent(ref GameObject child, GameObject parent, string name)
    {
        child = new GameObject(name);
        child.transform.SetParent(parent.transform);
    }

    private GameObject SetParentObject(PoolType poolType)
    {
        #region PoolAssignmentNotes
        //ZoneOneHybrids = _zoneOneHybridsEmpty
        //ZoneTwoHybrids = _zoneTwoHybridsEmpty
        //ZoneThreeHybrids  = _zoneThreeHybridsEmpty
        //ZoneFarmHybrids  = _zoneFarmHybridsEmpty
        //Seeds = _seedsEmpty
        //Plants = _plantsEmpty
        //Food =  _foodEmpty
        //Particales = _particalesEmpty
        //Sounds = _sounds
        //None
        #endregion

        switch (poolType)
        {
            case PoolType.GameObject:
                return _gameObjects;

            case PoolType.Particales:
                return _particalesEmpty;

            case PoolType.Sounds:
                return _sounds;

            case PoolType.None:
                return null;

            default:
                return null;

        }
    }



    public GameObject spawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.None)
    {
        //Debug.Log("SpawnObject Called");
        PooledObjectInfo pool = objectPools.Find(p => p.LookUpString == objectToSpawn.name);

        if (pool == null)
        {
            pool = new PooledObjectInfo() { LookUpString = objectToSpawn.name };
            objectPools.Add(pool);
            //Debug.Log("Created a new Pool");
        }

        // Check if there are any inactive objects in the pool
        GameObject spawnableObj = pool.inactiveObjects.FirstOrDefault();

        if (spawnableObj == null)
        {
            //Debug.Log("No Pooled Object To Pull");
            // Find the Parent of the empty Object
            GameObject parentObject = SetParentObject(poolType);

            // If there is no active object, create a new one
            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            //Debug.Log($"Created a new GameObject: {spawnableObj}");

            if (parentObject != null)
            {
                spawnableObj.transform.SetParent(parentObject.transform);
            }
        }
        else
        {
            Debug.Log("Found Pooled Object");
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.inactiveObjects.Remove(spawnableObj);
            pool.inactiveTimestamps.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7); // by taking off the 7, we are removing the (clone) from the passed in Obj

        PooledObjectInfo pool = objectPools.Find(p => p.LookUpString == goName);

        if (pool == null)
        {
            Debug.LogWarning("Trying To Releace An Object That is Not Pooled: " + obj.name);
        }
        else
        {
            obj.SetActive(false);
            pool.inactiveObjects.Add(obj);
            pool.inactiveTimestamps[obj] = Time.time;
        }
    }

    [Serializable]
    public class PooledObjectInfo
    {
        public string LookUpString;
        public List<GameObject> inactiveObjects = new List<GameObject>();
        public Dictionary<GameObject, float> inactiveTimestamps = new Dictionary<GameObject, float>();
    }

    private IEnumerator CheckInactiveObjects()
    {
        float checkInterval = 10f; // Interval to check for inactive objects
        float maxInactiveDuration = 60f; // Maximum allowed inactive duration

        while (true)
        {
            yield return new WaitForSeconds(checkInterval);

            foreach (PooledObjectInfo pool in objectPools)
            {
                List<GameObject> toRemove = new List<GameObject>();

                foreach (var kvp in pool.inactiveTimestamps)  //kvp = key value pair
                {
                    if (Time.time - kvp.Value > maxInactiveDuration && pool.inactiveObjects.Count > minPoolSize)
                    {
                        toRemove.Add(kvp.Key);
                    }
                }

                foreach (GameObject obj in toRemove)
                {
                    pool.inactiveObjects.Remove(obj);
                    pool.inactiveTimestamps.Remove(obj);
                    Destroy(obj); // Or handle the object removal as needed
                }
            }
        }

    }
}
