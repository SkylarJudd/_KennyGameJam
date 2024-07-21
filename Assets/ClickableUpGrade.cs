using DG.Tweening;
using Obvious.Soap;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.GridLayoutGroup;

public class ClickableUpGrade : MonoBehaviour
{
    [SerializeField] int startHealth;
    [SerializeField] int currentHealth;

    [SerializeField] GameObject clickableVisuals;

    [SerializeField] private IntReference currentBots;
    [SerializeField] private IntReference currentFuel;
    [SerializeField] private IntReference currentTitainium;

    [SerializeField] private IntReference currentFuelingStationDrones;
    [SerializeField] private IntReference currentRefinaryProduction;
    [SerializeField] private IntReference currentDrill;

    [SerializeField] private IntReference botAmoutPlus;
    [SerializeField] private IntReference fuelPlus;
    [SerializeField] private IntReference titainiumPlus;

    [SerializeField] private IntReference RefuelingPlus;
    [SerializeField] private IntReference refinaryPlus;
    [SerializeField] private IntReference drillPlus;

    
    [SerializeField] private Vector3 scale;
    [SerializeField] private float duration;

    [SerializeField] private bool _yoyo;
    [SerializeField] private Ease _easingType;

    [SerializeField] private string message;

    public SpawnClickable owner;



    private Vector3 _cachedScale;
    private float _cooldown;

    private void Start()
    {
        currentHealth = startHealth;
        _cachedScale = new Vector3(0.8f, 0.8f, 0.8f);
    }

    public void Update()
    {
        _cooldown -= Time.deltaTime;
    }
    public void OnClickClickableUpgrade()
    {
        print("Object Clicked");
        currentHealth--;
        clickVisuals();

        if (currentHealth <= 0)
        {
            TweenX.StopTween(clickableVisuals.transform);
            giveUpgrades();
            owner.clickableSpawnned = false;
            GameEvents.PlayerBrakeClickable(gameObject, message);
            Destroy(gameObject);
        }

    }

    public void clickVisuals()
    {
        TweenX.StopTween(clickableVisuals.transform);
        clickableVisuals.transform.localScale = _cachedScale;
        TweenX.TweenScale(clickableVisuals.transform, scale, duration, _yoyo, _easingType);
    }

    public void giveUpgrades()
    {
        currentBots.Value += botAmoutPlus;
        currentFuel.Value += fuelPlus;
        currentTitainium.Value += titainiumPlus;

        currentFuelingStationDrones.Value += RefuelingPlus;
        currentRefinaryProduction.Value += refinaryPlus;
        currentDrill.Value += drillPlus;
    }
   

}
