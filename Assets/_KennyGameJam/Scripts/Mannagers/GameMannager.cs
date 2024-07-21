
using Obvious.Soap;
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

    public ScriptableEventNoParam OnGameStateChanged;

    #region("Event Exsample")
    private void GameEvents_GameEventExsampleDo(GameObject _go)
    {
        //Do Something From Event
    }
    #endregion

    private void Start()
    {
        SetGameState(GameState.Menu);
    }

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

    public void SetGameState(GameState _gameState)
    {
        gameState = _gameState;
        OnGameStateChanged.Raise(); //Raise Event
    }
}
