using System;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public static class GameEvents
{
    #region ("Exsample of adding action")
    public static event Action<GameObject> OnGameEventExsample = null;
    #endregion
    public static event Action<GameObject> OnPlayerClickBuildable = null;
    public static event Action<GameObject> OnPlayerClickBuildableBuilt = null;
    public static event Action<GameObject> OnPlayerClickNotOnBuildable = null;
    public static event Action<GameObject> OnPlayerMouseOverBuildable = null;
    public static event Action<GameObject, string> OnPlayerBrakeClickable = null;
    public static event Action<GameObject> OnGameWin = null;

    public static event Action<GameObject> OnEnermyHit = null;
    public static event Action<GameObject> OnEnermyDie = null;

    public static event Action<GameObject> OnChickenEnemyHit = null;
    public static event Action<GameObject> OnChickenEnemyDie = null;


    #region ("Exsample of adding action")
    public static void GameEventExsample(GameObject go)
    {
        OnGameEventExsample?.Invoke(go);
    }
    #endregion

    public static void PlayerClickBuildable(GameObject go)
    {

        OnPlayerClickBuildable?.Invoke(go);
    }

    public static void PlayerMouseOverBuildable(GameObject go)
    {
        OnPlayerMouseOverBuildable?.Invoke(go);
    }

    public static void PlayerClickBuildableBuilt(GameObject go)
    {
        OnPlayerClickBuildableBuilt?.Invoke(go);
    }

    public static void PlayerClickNotOnBuildable(GameObject go)
    {
        OnPlayerClickNotOnBuildable?.Invoke(go);
    }

    public static void PlayerBrakeClickable(GameObject go, string _Text)
    {
        OnPlayerBrakeClickable?.Invoke(go, _Text);
    }

    public static void WinGame(GameObject go)
    {
        OnGameWin?.Invoke(go);
    }

    public static void ReportOnEnemyHit(GameObject go)
    {
        OnEnermyHit?.Invoke(go);
    }

    public static void ReportOnEnemyDie(GameObject go)
    {
        OnEnermyDie?.Invoke(go);
    }

    public static void ReportOnChickenEnemyHit(GameObject go)
    {
        Debug.Log("ChickenHitEvent Fired");
        OnChickenEnemyHit?.Invoke(go);

    }

    public static void ReportOnChickenEnemyDie(GameObject go)
    {
        Debug.Log("ChickenDiedEvent Fired");
        OnChickenEnemyDie?.Invoke(go);

    }

}
