using Obvious.Soap;
using UnityEngine;
using UnityEngine.UIElements;

public enum SelectedBuilding { None, FuelRefinery, RefuelingStation, TitaniumMine }

public class BuildUIController : GameBehaviour
{
    public SelectedBuilding selectedBuilding;

    public GameObject costTextRefinery;
    public GameObject costTextRefuel;
    public GameObject costTextMine;
    
    
    public void OnFuelRefineryClick() => _UIM.OnFuelRefineryClick();
    public void OnFuelRefineryMouseOver()
    {
        selectedBuilding = SelectedBuilding.FuelRefinery;
        costTextRefinery.SetActive(true);
        costTextRefuel.SetActive(false);
        costTextMine.SetActive(false);
    }

    public void OnFuelRefineryMouseExit()
    {
        selectedBuilding = SelectedBuilding.None;
        costTextRefinery.SetActive(false);
    }


    public void OnRefuelingStationClick() => _UIM.OnRefuelingStationClick();
    public void OnRefuelingStationMouseOver()
    {
        selectedBuilding = SelectedBuilding.RefuelingStation;
        costTextRefuel.SetActive(true);
        costTextMine.SetActive(false);
        costTextRefinery.SetActive(false);
    }
    public void OnRefuelingStationMouseExit()
    {
        selectedBuilding = SelectedBuilding.None;
        costTextRefuel.SetActive(false);
    }

    public void OnTitaniumMineClick() => _UIM.OnTitaniumMinelick();

    public void OnTitaniumMineMouseOver()
    {
        selectedBuilding = SelectedBuilding.TitaniumMine;
        costTextMine.SetActive(true);
        costTextRefinery.SetActive(false);
        costTextRefuel.SetActive(false);
    }
    public void OnTitaniumMineMouseExit()
    {
        selectedBuilding = SelectedBuilding.None;
        costTextMine.SetActive(false);
    }

    public void OnExitBuild() => _UIM.BuildUiHide();
    public void OnExitBuilt() => _UIM.BuiltUiHide();

    public void OnDestroyClick() => _UIM.OnDestroyClick();






}
