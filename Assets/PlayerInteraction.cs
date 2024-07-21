using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum BuildUiClickState { FuelRefinery, RefuelingStation , TitaniumMine }

public class PlayerInteraction : Singleton<PlayerInteraction>
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private LayerMask buildableLayerMask;
    [SerializeField] private LayerMask buildableBiltLayerMask;

    [SerializeField] private GameObject lastClickedBuildable;



    [Header("Building Prefabs")]
    [SerializeField] private GameObject fuelRefineryPrefab;
    [SerializeField] private GameObject refuelingStationPrefab;
    [SerializeField] private GameObject titaniumMinerefab;

    float clickCooldownTimer;

    Vector3 mouseWorldPosition = Vector3.zero;

    public void Update()
    {
        OnHover();

        if (clickCooldownTimer < 0) clickCooldownTimer = 0; else clickCooldownTimer -= Time.deltaTime;
    }

    public void OnClick(InputAction.CallbackContext _context)
    {

        if (_context.ReadValue<float>() == 0)
            return;

        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out RaycastHit raycastHit3, Mathf.Infinity))
        {
            LayerMask layerMask = raycastHit3.transform.gameObject.layer;

            switch (LayerMask.LayerToName(layerMask))
            {
                case "Buildable":
                    print("Clicked On Dirt");
                    lastClickedBuildable = raycastHit3.transform.gameObject;
                    BuildableArea buildableArea = raycastHit3.transform.gameObject.GetComponent<BuildableArea>();

                    if (buildableArea.built != true && buildableArea.locked != true)
                    {
                        mouseWorldPosition = raycastHit3.point;
                        GameEvents.PlayerClickBuildable(lastClickedBuildable);
                        return;
                    }
                    return;
                case "Building":

                    print("Clicked On Building");
                    lastClickedBuildable = raycastHit3.transform.gameObject;
                    mouseWorldPosition = raycastHit3.point;
                    GameEvents.PlayerClickBuildableBuilt(lastClickedBuildable.GetComponent<BuildableObject>().UiTransform.gameObject);
                    return;

                case "ClickableUpgrade":
                    if(clickCooldownTimer <= 0)
                    {
                        clickCooldownTimer = 0.2f;
                        ClickableUpGrade clickable = raycastHit3.transform.gameObject.GetComponent<ClickableUpGrade>();
                        clickable.OnClickClickableUpgrade();
                    }
                    
                    return;

                default:
                    return;
            }
        }
        else
        {

            StartCoroutine(CloseWindowDelay());
        }
    }
    
    public void OnHover()
    {
        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit3, Mathf.Infinity))
        {
            LayerMask layerMask = raycastHit3.transform.gameObject.layer;

            switch (LayerMask.LayerToName(layerMask))
            {
                case "Buildable":
                    lastClickedBuildable = raycastHit3.transform.gameObject;
                    BuildableArea buildableArea = raycastHit3.transform.gameObject.GetComponent<BuildableArea>();
                    GameObject lastSelectedBuildableArea = raycastHit3.transform.gameObject;

                    if (buildableArea.built != true && buildableArea.locked != true)
                    {
                        mouseWorldPosition = raycastHit3.point;
                        GameEvents.PlayerMouseOverBuildable(lastSelectedBuildableArea);
                        return;
                    }
                    return;

                case "Building":
                    return;

               
                default:
                    return;
            }
        }
        else
        {

            return;
        }
    }

    private IEnumerator CloseWindowDelay()
    {
        yield return new WaitForSeconds(0.1f);
        GameEvents.PlayerClickNotOnBuildable(gameObject);
    }
    public void BuildUIClicked(BuildUiClickState _buildUiClickState)
    {
        switch (_buildUiClickState)
        {
            case BuildUiClickState.FuelRefinery:
                InstatiateBuildable(fuelRefineryPrefab);
                break;
            case BuildUiClickState.RefuelingStation:
                InstatiateBuildable(refuelingStationPrefab);
                break;

            case BuildUiClickState.TitaniumMine:
                InstatiateBuildable(titaniumMinerefab);
                break;

            default:
                break;
        }
    }

    private void InstatiateBuildable(GameObject _Buildable)
    {
        BuildableArea area = lastClickedBuildable.GetComponent<BuildableArea>();
        
        BuildableObject buildable = _Buildable.GetComponent<BuildableObject>();
        if (buildable != null)
        {
            if ((buildable.currentTitanium - buildable.titaniumCost) >= 0 && (buildable.currentDrones - buildable.DroneCost) >= 0)
            {
                GameObject spawnedBuilding = Instantiate(_Buildable, area.connectTransform);
                area.SetBuiltToTrue();

            }
            else
            {
                print("Not Enough Money");
            }
        }
       
        
    }

    public void DestroyBuilding()
    {
        BuildableArea buildableArea = lastClickedBuildable.GetComponentInParent<BuildableArea>();
        BuildableObject buildableObject = lastClickedBuildable.GetComponent<BuildableObject>();

        if (buildableObject.buildingType == BuildingType.FuelingStation)
        {
            if(buildableObject.currentDrones < buildableObject.DroneProduction)
            {
                Debug.Log("Not Enough Drones To Destroy This Building!");
                return;
            }
            else
            {
                buildableArea.SetBuiltToFalse();
                Destroy(lastClickedBuildable);
            }
        }
        else
        {
            buildableArea.SetBuiltToFalse();
            Destroy(lastClickedBuildable);
        }
    }
}
