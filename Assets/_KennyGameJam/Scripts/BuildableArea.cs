using UnityEngine;

public class BuildableArea : MonoBehaviour
{
    public Transform connectionTransform;
    public bool built;
    public GameObject visibileNode;

    private void GameEvents_OnPlayerMouseOverBuildable(GameObject obj)
    {
        if (obj == gameObject)
        {
            visibileNode.SetActive(true);
        }
        else
        {
            visibileNode.SetActive(false);
        }
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerMouseOverBuildable += GameEvents_OnPlayerMouseOverBuildable;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerMouseOverBuildable -= GameEvents_OnPlayerMouseOverBuildable;

    }
}
