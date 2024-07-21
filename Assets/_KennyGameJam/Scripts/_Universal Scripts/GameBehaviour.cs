
using UnityEngine;
using System.Collections.Generic;

public class GameBehaviour : MonoBehaviour
{
    protected static GameMannager _GM { get { return GameMannager.instance; } }
    protected static ObjectPoolManager _OPM { get { return ObjectPoolManager.instance; } }
    protected static PlayerInteraction _PI { get { return PlayerInteraction.instance; } }
    protected static UIMannager _UIM { get { return UIMannager.instance; } }
    protected static SceneController _SC { get { return SceneController.instance; } }







}
