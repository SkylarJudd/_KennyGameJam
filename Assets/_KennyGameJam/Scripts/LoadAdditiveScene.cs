using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAdditiveScene : MonoBehaviour
{
    [SerializeField] private SceneAsset sceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Additive);
    }
}
