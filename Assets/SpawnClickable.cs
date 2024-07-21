using System.Collections;
using UnityEngine;

public class SpawnClickable : MonoBehaviour
{
    [SerializeField] GameObject[] clickables;
    public bool clickableSpawnned;

    public void GameStateCheck()
    {
        switch(GameMannager.instance.gameState)
        {
            case GameState.Playing:
                StartCoroutine(spawnClickable(Random.Range(30, 120)));
                break;
            case GameState.GameOver:
                StopAllCoroutines();
                break;
            case GameState.Paused:
                StopAllCoroutines();
                break;
            case GameState.Menu:
                StopAllCoroutines();
                break;
            case GameState.Win:
                StopAllCoroutines();
                break;
            default:
                break;
        }
        StopAllCoroutines();
    }

    IEnumerator spawnClickable(float _seconds)
    {
        print("Looping");
        yield return new WaitForSeconds(_seconds);

        if (!clickableSpawnned)
        {
            if(Random.Range(1,5) == 1) 
            {
                GameObject spawnedObject = Instantiate(clickables[Random.Range(0, clickables.Length)], gameObject.transform);
                spawnedObject.GetComponent<ClickableUpGrade>().owner = this;
                clickableSpawnned = true;
            }
        }
        // Call the coroutine again to continue looping
        StartCoroutine(spawnClickable(Random.Range(30, 120)));
    }
}
