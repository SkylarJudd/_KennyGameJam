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
    [SerializeField] private IntReference titaniumCost;
    [SerializeField] private IntReference fuelCost;
    [SerializeField] private IntReference DroneCost;

    [Header("Building Production")]
    [SerializeField] private IntReference titaniumProduction;
    [SerializeField] private IntReference fuelProduction;
    [SerializeField] private IntReference DroneProduction;

    [Header("VariableReferences")]
    [SerializeField] private IntReference currentTitanium;
    [SerializeField] private IntReference currentFuel;
    [SerializeField] private IntReference currentDrones;

    [SerializeField] private IntReference fuelIncreaseRate;
    [SerializeField] private IntReference fuelDecreaseRate;
    [SerializeField] private IntReference titaniumIncreaseRate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        HandleCosts();
        HandleProduction();
    }

    void HandleCosts()
    {
        currentTitanium.Value -= titaniumCost.Value;
        currentDrones.Value -= DroneCost.Value;
        fuelDecreaseRate.Value += fuelCost.Value;
    }

    void HandleProduction()
    {
        fuelIncreaseRate.Value += fuelProduction.Value;
        titaniumIncreaseRate.Value += titaniumProduction.Value;
        currentDrones.Value += DroneProduction.Value;
    }
}
