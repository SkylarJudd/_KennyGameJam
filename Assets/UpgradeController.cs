using UnityEngine;

public class UpgradeController : GameBehaviour
{
    [SerializeField] GameObject ShopUpgradeVisuals;


    private void OnEnable()
    {
        GameEvents.OnGameWin += GameEvents_OnGameWin;
    }

    private void OnDisable()
    {
        GameEvents.OnGameWin -= GameEvents_OnGameWin;
    }

    private void GameEvents_OnGameWin(GameObject obj)
    {
        ShopUpgradeVisuals.SetActive(false);
    }

    public void OnUpGradePressed()
    {
        _GM.CheckIfCanUpgrade();
    }
}
