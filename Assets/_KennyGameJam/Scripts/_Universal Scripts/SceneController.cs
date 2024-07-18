
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string _sceneName) => SceneManager.LoadSceneAsync(_sceneName);
  
    public void ReloadScene() => LoadScene(SceneManager.GetActiveScene().name);
   
    public void LoadTitleScreen() => LoadScene("MainMenu");
   
    public void Quit() => Application.Quit();
    

}
