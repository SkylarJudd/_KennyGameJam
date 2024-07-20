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

    Vector3 mouseWorldPosition = Vector3.zero;
    public void OnClick(InputAction.CallbackContext _context)
    {

        if (_context.ReadValue<float>() == 0)
            return;

        Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, buildableLayerMask))
        {
            lastClickedBuildable = raycastHit.transform.gameObject;

            if (lastClickedBuildable .GetComponent<BuildableArea>().built != true)
            {
                mouseWorldPosition = raycastHit.point;
                GameEvents.PlayerClickBuildable(lastClickedBuildable);
                return;
            }  
        }
        else if (Physics.Raycast(ray, out RaycastHit raycastHit2, Mathf.Infinity, buildableBiltLayerMask))
        {
            lastClickedBuildable = raycastHit2.transform.gameObject;
            mouseWorldPosition = raycastHit2.point;
            GameEvents.PlayerClickBuildableBuilt(lastClickedBuildable.GetComponent<BuildableObject>().UiTransform.gameObject);
            return;
        }

        else
        {
            
        }
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
        Instantiate(_Buildable, area.connectionTransform);
    }

    public void DestroyBuilding()
    {
        Destroy(lastClickedBuildable);
    }
}
