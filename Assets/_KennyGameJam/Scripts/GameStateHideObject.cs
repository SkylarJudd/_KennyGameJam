using UnityEngine;

public class GameStateHideObject : MonoBehaviour
{
    [SerializeField] private GameState[] gameStatesToHide;
    [SerializeField] private GameState[] gameStatesToShow;

    [SerializeField] private GameObject[] gameObjectsToHide;

    public void Process()
    {
        foreach (var gameState in gameStatesToHide)
        {
            foreach (var gameObject in gameObjectsToHide)
            {
                if (GameMannager.instance.gameState == gameState)
                {
                    gameObject.SetActive(false);
                }
            }   
        }

        foreach (var gameState in gameStatesToShow)
        {
            foreach (var gameObject in gameObjectsToHide)
            {
                if (GameMannager.instance.gameState == gameState)
                {
                    gameObject.SetActive(true);
                }

            }  
        }
    }
}