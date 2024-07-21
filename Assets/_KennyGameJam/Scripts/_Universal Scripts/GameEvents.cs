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
    public static event Action<GameObject,string> OnPlayerBrakeClickable = null;


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


}
