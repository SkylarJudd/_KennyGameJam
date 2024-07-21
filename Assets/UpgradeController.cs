using UnityEngine;

public class UpgradeController : GameBehaviour
{
    public void OnUpGradePressed()
    {
        _GM.CheckIfCanUpgrade();
    }
}
