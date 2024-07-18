
using UnityEngine;

public enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver,
}

public enum Difficulty
{
    Eazy,
    Medium,
    Hard,
}

public class GameMannager : Singleton<GameMannager>
{
    public GameState gameState = GameState.Menu;
    public Difficulty difficuty;

    #region("Event Exsample")
    private void GameEvents_GameEventExsampleDo(GameObject _go)
    {
        //Do Something From Event
    }
    #endregion

    private void OnEnable()
    {
        #region("Subscribe to event Example")
        GameEvents.OnGameEventExsample += GameEvents_GameEventExsampleDo;
        #endregion

    }



    private void OnDisable()
    {
        #region("Unsubscribe to event Example")
        GameEvents.OnGameEventExsample -= GameEvents_GameEventExsampleDo;
        #endregion

    }
}
