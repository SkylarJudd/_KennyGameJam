using UnityEngine;

public class WinScreenController : GameBehaviour
{
    [SerializeField] GameObject winscreen;

    private void Awake()
    {
        GameEvents.OnGameWin += GameEvents_OnGameWin;
    }

    private void OnDisable()
    {
        GameEvents.OnGameWin -= GameEvents_OnGameWin;
    }

    private void GameEvents_OnGameWin(GameObject obj)
    {
        winscreen.SetActive(true);
    }

    public void Onrestartclick()
    {
        _SC.ReloadScene();
    }
    public void OnExitPressed()
    {
        _SC.Quit();
    }

}
