using UnityEngine;

public class BuildableArea : MonoBehaviour
{
    public Transform connectTransform;
    public BuildableArea[] connectedBuildables;
    public BuildableArea[] perentBuildables;
    public bool built;
    public bool locked;
    public GameObject visibileNode;


    public GameObject connectedRoadNormal;
    public GameObject connectedRoadHighlighted;

    [SerializeField] bool isStarter;

    private void Start()
    {
        if (isStarter != true)
        {
            locked = true;
        }

        if (connectedBuildables.Length == 0)
            return;

        connectedRoadNormal.SetActive(true);
        connectedRoadHighlighted.SetActive(false);
    }
    private void GameEvents_OnPlayerMouseOverBuildable(GameObject obj)
    {
        if (obj == gameObject)
        {
            visibileNode.SetActive(true);
        }
        else
        {
            visibileNode.SetActive(false);
        }
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerMouseOverBuildable += GameEvents_OnPlayerMouseOverBuildable;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerMouseOverBuildable -= GameEvents_OnPlayerMouseOverBuildable;

    }

    public void SetBuiltToTrue()
    {
        built = true;

        if (connectedBuildables.Length == 0)
           return;
        
        connectedRoadNormal.SetActive(false);
        connectedRoadHighlighted.SetActive(true);

        foreach(BuildableArea _BuildArea in connectedBuildables)
        {
            _BuildArea.Unlock();
        }
    }

    public void SetBuiltToFalse()
    {
        built = false;

        if (connectedBuildables.Length == 0)
            return;

        connectedRoadNormal.SetActive(true);
        connectedRoadHighlighted.SetActive(false);
        foreach (BuildableArea _BuildArea in connectedBuildables)
        {
            _BuildArea.Lock();
        }
    }

    public void Lock()
    {
        if (connectedBuildables.Length != 0)
        {
            foreach (BuildableArea _BuildArea in perentBuildables)
            {
                bool perentBuilt = false;

                if (_BuildArea.built == true)
                {
                    perentBuilt = true;
                }

                if ( perentBuilt != true)
                {
                    locked = true;
                }
            }
        }
        else
        {
            locked = true;
        }
    }

    public void Unlock() 
    { 
        locked = false; 
    }
}
