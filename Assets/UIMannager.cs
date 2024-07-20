using UnityEngine;

public class UIMannager : Singleton<UIMannager>
{
    [SerializeField] GameObject buildUI;
    [SerializeField] GameObject builtUI;
    public bool buildMenuOpen;
    public bool builtMenuOpen;
    private void GameEvents_OnPlayerClickBuildable(GameObject obj)
    {
        BuildUiShow(obj.transform);
    }
    private void GameEvents_OnPlayerClickNotOnBuildable(GameObject obj)
    {
        BuildUiHide();
        BuiltUiHide();
    }
    private void GameEvents_OnPlayerClickBuildableBuilt(GameObject obj)
    {
        BuiltUiShow(obj.transform);
    }
    public void BuildUiShow(Transform position)
    {
        //print("called");
        buildMenuOpen = true;
        buildUI.SetActive(true);
        buildUI.transform.position = position.position;
        BuiltUiHide();
    }
    public void BuiltUiShow(Transform position)
    {
        //print("called");
        builtMenuOpen = true;
        builtUI.SetActive(true);
        builtUI.transform.position = position.position;
        BuildUiHide();
    }

    public void BuildUiHide()
    {
        buildMenuOpen = false;
        buildUI.SetActive(false);
    }
    public void BuiltUiHide()
    {
        builtMenuOpen = false;
        builtUI.SetActive(false);
    }

    public void OnFuelRefineryClick()
    {
        _PI.BuildUIClicked(BuildUiClickState.FuelRefinery);
        BuildUiHide();
    }
    public void OnRefuelingStationClick()
    {
        _PI.BuildUIClicked(BuildUiClickState.RefuelingStation);
        BuildUiHide();
    }
    public void OnTitaniumMinelick()
    {
        _PI.BuildUIClicked(BuildUiClickState.TitaniumMine);
        BuildUiHide();
    }
    public void OnDestroyClick()
    {
        _PI.DestroyBuilding();
        BuildUiHide();
        BuiltUiHide();

    }



    private void OnEnable()
    {
        GameEvents.OnPlayerClickBuildable += GameEvents_OnPlayerClickBuildable;
        GameEvents.OnPlayerClickNotOnBuildable += GameEvents_OnPlayerClickNotOnBuildable;
        GameEvents.OnPlayerClickBuildableBuilt += GameEvents_OnPlayerClickBuildableBuilt;
    }



    private void OnDisable()
    {
        GameEvents.OnPlayerClickBuildable -= GameEvents_OnPlayerClickBuildable;
        GameEvents.OnPlayerClickNotOnBuildable -= GameEvents_OnPlayerClickNotOnBuildable;
        GameEvents.OnPlayerClickBuildableBuilt -= GameEvents_OnPlayerClickBuildableBuilt;
    }


}
