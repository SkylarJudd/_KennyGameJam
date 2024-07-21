using UnityEngine;

public class ChangeGameState : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    public void Change()
    {
        GameMannager.instance.SetGameState(gameState);
    }
}
