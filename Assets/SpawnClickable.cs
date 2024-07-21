using System.Collections;
using UnityEngine;

public class SpawnClickable : MonoBehaviour
{
    [SerializeField] GameObject[] clickables;
    public bool clickableSpawnned;

    private void Start()
    {
        StartCoroutine(spawnClickable(Random.Range(5, 120)));
    }

    IEnumerator spawnClickable(float _seconds)
    {
        print("Looping");
        yield return new WaitForSeconds(_seconds);

        if (!clickableSpawnned)
        {
            GameObject spawnedObject = Instantiate(clickables[Random.Range(0, clickables.Length)], gameObject.transform);
            spawnedObject.GetComponent<ClickableUpGrade>().owner = this;
            clickableSpawnned = true;
        }

        // Call the coroutine again to continue looping
        StartCoroutine(spawnClickable(Random.Range(30, 120)));
    }
}
