using UnityEngine;
using UnityEngine.UIElements;

public class BuildUIController : GameBehaviour
{
    public void OnFuelRefineryClick() => _UIM.OnFuelRefineryClick();
    public void OnFuelRefineryMouseOver()
    {

    }
    public void OnFuelRefineryMouseExit()
    {

    }


    public void OnRefuelingStationClick() => _UIM.OnRefuelingStationClick();
    public void OnRefuelingStationMouseOver()
    {

    }
    public void OnRefuelingStationMouseExit()
    {

    }

    public void OnTitaniumMineClick() => _UIM.OnTitaniumMinelick();

    public void OnTitaniumMineMouseOver()
    {

    }
    public void OnTitaniumMineMouseExit()
    {

    }

    public void OnExitBuild() => _UIM.BuildUiHide();
    public void OnExitBuilt() => _UIM.BuiltUiHide();

    public void OnDestroyClick() => _UIM.OnDestroyClick();






}
