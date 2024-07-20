using Obvious.Soap;
using UnityEngine;

public enum BuildingType
{
    Refinery,
    FuelingStation,
    Drill
}

public class BuildableObject : MonoBehaviour
{
    [SerializeField] private BuildingType buildingType;
    public Transform UiTransform;

    [Header("Building Cost")]
    public IntReference titaniumCost;
    [SerializeField] private IntReference fuelCost;
    public IntReference DroneCost;

    [Header("Building Production")]
    [SerializeField] private IntReference titaniumProduction;
    [SerializeField] private IntReference fuelProduction;
    [SerializeField] private IntReference DroneProduction;

    [Header("VariableReferences")]
    public IntReference currentTitanium;
    [SerializeField] private IntReference currentFuel;
    public IntReference currentDrones;

    [SerializeField] private IntReference fuelIncreaseRate;
    [SerializeField] private IntReference fuelDecreaseRate;
    [SerializeField] private IntReference titaniumIncreaseRate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        HandleCosts(false);
        HandleProduction(false);
    }

    private void OnDisable()
    {
        HandleCosts(true);
        HandleProduction(true);
    }

    void HandleCosts(bool _destruction)
    {
        currentTitanium.Value -= _destruction == true ? -titaniumCost.Value :  titaniumCost.Value;
        currentDrones.Value -= _destruction == true ? -DroneCost.Value : DroneCost.Value;
        fuelDecreaseRate.Value -= _destruction == true ? -fuelCost.Value : fuelCost.Value;
    }

    void HandleProduction(bool _destruction)
    {
        fuelIncreaseRate.Value += _destruction == true ? -fuelProduction.Value : fuelProduction.Value;
        titaniumIncreaseRate.Value += _destruction == true ? -titaniumProduction.Value : titaniumProduction.Value;
        currentDrones.Value += _destruction == true ? -DroneProduction.Value : DroneProduction.Value;

    }
}
