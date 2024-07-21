
using UnityEngine;
using System.Collections.Generic;

public class GameBehaviour : MonoBehaviour
{
    protected static GameMannager _GM { get { return GameMannager.instance; } }
    protected static ObjectPoolManager _OPM { get { return ObjectPoolManager.instance; } }
    protected static PlayerInteraction _PI { get { return PlayerInteraction.instance; } }
    protected static UIMannager _UIM { get { return UIMannager.instance; } }
    protected static SceneController _SC { get { return SceneController.instance; } }

    protected static ChickenEnermyMannager _CEM { get { return ChickenEnermyMannager.instance; } }
    protected static ChickenEnermyNavMannager _CNM { get { return ChickenEnermyNavMannager.instance; } }

    public ValidNavPoints FindClosestNavPoint(Transform _currentLocation, List<ValidNavPoints> _objects)
    {
        if (_objects == null || _objects.Count == 0)
            return null;

        float distance = Mathf.Infinity;
        ValidNavPoints closest = null;

        foreach (ValidNavPoints go in _objects)
        {
            float currentDistance = Vector3.Distance(_currentLocation.transform.position, go.transform.position);
            if (currentDistance < distance)
            {
                closest = go;
                distance = currentDistance;
            }
        }
        return closest;
    }



}
