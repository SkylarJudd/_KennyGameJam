using System;
using UnityEngine;


public static class GameEvents
{
    #region ("Exsample of adding action")
    public static event Action<GameObject> OnGameEventExsample = null;
    #endregion


    #region ("Exsample of adding action")
    public static void GameEventExsample(GameObject go)
    {
        OnGameEventExsample?.Invoke(go);
    }
    #endregion
}
