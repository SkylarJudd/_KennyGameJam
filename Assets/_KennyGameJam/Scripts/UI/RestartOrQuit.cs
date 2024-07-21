using UnityEngine;

public class RestartOrQuit : GameBehaviour
{
    public void Onrestartclick()
    {
        _SC.ReloadScene();
    }
    public void OnExitPressed()
    {
        _SC.Quit();
    }
}
