using UnityEngine;

public class builtUiController : GameBehaviour
{
    public void OnExitBuilt() => _UIM.BuiltUiHide();

    public void OnDestroyClick() => _UIM.OnDestroyClick();
}
