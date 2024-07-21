
using Obvious.Soap;
using UnityEngine;

public enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver,
    Win,
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

    public int shipLevel;

    [SerializeField] private IntReference fuelAmountCurrent;
    [SerializeField] private IntReference titaniumAmoutCurrent;

    [SerializeField] private IntReference[] neededFuelToLevel;
    [SerializeField] private IntReference[] neededTitaniumToLevel;

    [SerializeField] private IntReference upgradefuelAmountCurrentUI;
    [SerializeField] private IntReference upgradetitaniumAmoutCurrentUI;
    [SerializeField] private IntReference upgradeShipLevelUI;

    #region("Event Exsample")
    private void GameEvents_GameEventExsampleDo(GameObject _go)
    {
        //Do Something From Event
    }
    #endregion

    private void Start()
    {
        SetGameState(GameState.Menu);
        UpdateUIBuyValues();
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

    public void voidUpdateShipLevel()
    {
        shipLevel++;



        if (shipLevel == 2)
        {
            //player wins ship takes off
            gameState = GameState.Win;
            GameEvents.WinGame(gameObject);
        }
    }

    public void CheckIfCanUpgrade()
    {
        if (fuelAmountCurrent >= neededFuelToLevel[shipLevel] && titaniumAmoutCurrent >= neededTitaniumToLevel[shipLevel])
        {
            fuelAmountCurrent.Value -= neededFuelToLevel[shipLevel];
            titaniumAmoutCurrent.Value -= neededTitaniumToLevel[shipLevel];
            voidUpdateShipLevel();
            UpdateUIBuyValues();

        }
    }

    void UpdateUIBuyValues()
    {
        upgradefuelAmountCurrentUI.Value = neededFuelToLevel[shipLevel];
        upgradetitaniumAmoutCurrentUI.Value = neededTitaniumToLevel[shipLevel];
        upgradeShipLevelUI.Value = shipLevel + 1;
    }
}
