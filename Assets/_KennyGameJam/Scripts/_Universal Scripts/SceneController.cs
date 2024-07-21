
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public void LoadScene(string _sceneName) => SceneManager.LoadSceneAsync(_sceneName);
  
    public void ReloadScene() => LoadScene(SceneManager.GetActiveScene().name);
   
    public void LoadTitleScreen() => LoadScene("MainMenu");
   
    public void Quit() => Application.Quit();
    

}
