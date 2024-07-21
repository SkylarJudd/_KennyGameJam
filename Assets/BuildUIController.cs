using Obvious.Soap;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum SelectedBuilding { None, FuelRefinery, RefuelingStation, TitaniumMine }

public class BuildUIController : GameBehaviour
{
    public SelectedBuilding selectedBuilding;

    public GameObject costTextRefinery;
    public GameObject costTextRefuel;
    public GameObject costTextMine;


    [SerializeField] Sprite cantBuyVisualDrill;
    [SerializeField] Sprite cantBuyVisualFueling;
    [SerializeField] Sprite cantBuyVisualRefinery;

    [SerializeField] Sprite canBuyVisualDrill;
    [SerializeField] Sprite canBuyVisualFueling;
    [SerializeField] Sprite canBuyVisualRefinery;

    [SerializeField]  UnityEngine.UI.Image BuyVisualDrill;
    [SerializeField]  UnityEngine.UI.Image BuyVisualFueling;
    [SerializeField]  UnityEngine.UI.Image BuyVisualRefinery;

    [SerializeField] private IntReference currentBots;
    [SerializeField] private IntReference currentTitainium;

   
    [SerializeField] private IntReference drillDroneCost;
    [SerializeField] private IntReference drillitainiumCost;

    [SerializeField] private IntReference fuelingDroneCost;
    [SerializeField] private IntReference fuelingTitainiumCost;

    [SerializeField] private IntReference refineryDroneCost;
    [SerializeField] private IntReference refineryitainiumCost;

    private void Start()
    {
       
    }

    private void Update()
    {
        checkIfCanBuy();
    }


    void checkIfCanBuy()
    {
       

        // Checks if can buy drill
        if (currentBots >= drillDroneCost && currentTitainium >= drillitainiumCost)
        {
            SetDrillBuyActive(false);
        }
        else
        {
            SetDrillBuyActive(true);
        }

        // Checks if can buy fueling
        if (currentTitainium >= fuelingTitainiumCost)
        {
            SetFuelingBuyActive(false);
        }
        else
        {
            SetFuelingBuyActive(true);
        }

        // Checks if can buy refinery
        if (currentBots >= refineryDroneCost && currentTitainium >= refineryitainiumCost)
        {
            SetRefineryBuyActive(false);
        }
        else
        {
            SetRefineryBuyActive(true);
        }

    }

    void SetDrillBuyActive(bool _active)
    {
        if (BuyVisualDrill == null)
        {
            Debug.LogError("BuyVisualDrill is not assigned!");
            return;
        }

        BuyVisualDrill.sprite = _active ? cantBuyVisualDrill : canBuyVisualDrill;
    }

    void SetFuelingBuyActive(bool _active)
    {
        if (BuyVisualFueling == null)
        {
            Debug.LogError("BuyVisualFueling is not assigned!");
            return;
        }

        BuyVisualFueling.sprite = _active ? cantBuyVisualFueling : canBuyVisualFueling;
    }

    void SetRefineryBuyActive(bool _active)
    {
        if (BuyVisualRefinery == null)
        {
            Debug.LogError("BuyVisualRefinery is not assigned!");
            return;
        }

        BuyVisualRefinery.sprite = _active ? cantBuyVisualRefinery : canBuyVisualRefinery;
    }


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
