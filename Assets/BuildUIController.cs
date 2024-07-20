using UnityEngine;
using UnityEngine.UIElements;

public class BuildUIController : GameBehaviour
{
    [SerializeField] GameObject buildUI;
     private void GameEvents_OnPlayerClickBuildable(GameObject obj)
    {
        
        BuildUiShow(obj.transform);
    }
    public void BuildUiShow(Transform position)
    {
        print("called");
        buildUI.SetActive(true);
        buildUI.transform.position = position.position;
    }

    public void BuildUiHide()
    {
        buildUI.SetActive(true);
    }

    public void OnFuelRefineryClick()
    {

    }
    public void OnRefuelingStationClick()
    {

    }
    public void OnTitaniumMinelick()
    {

    }

    private void OnEnable()
    {

        GameEvents.OnPlayerClickBuildable += GameEvents_OnPlayerClickBuildable; ;
       

    }

    private void OnDisable()
    {
        
        GameEvents.OnPlayerClickBuildable -= GameEvents_OnPlayerClickBuildable;
        

    }

}
