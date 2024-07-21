using System.Collections;
using TMPro;
using UnityEngine;

public class PluseClickableController : GameBehaviour
{
    [SerializeField] GameObject plusUpgradeGO;
    [SerializeField]  Vector3 offset;
    [SerializeField]  float moveupSpeed;
    [SerializeField]  TMP_Text plusUpgradeText;

    bool _uppies;
    Coroutine _hidePlusUpgradeAfterDelay;

    private void Start()
    {
        plusUpgradeGO.SetActive(false);
    }
    private void GameEvents_OnPlayerBrakeClickable(GameObject go, string _string)
    {
        ShowPlusUpgrade();
        _uppies = true;
        plusUpgradeText.text = _string;
        plusUpgradeGO.transform.position = go.transform.position + offset;

        if (_hidePlusUpgradeAfterDelay != null)
            StopCoroutine( _hidePlusUpgradeAfterDelay );


        _hidePlusUpgradeAfterDelay = StartCoroutine(HidePlusUpgradeAfterDelay());
    }

    IEnumerator HidePlusUpgradeAfterDelay()
    {
        yield return new WaitForSeconds(2.5f);
        HidePlusUpgrade();
    }

    void ShowPlusUpgrade()
    {
        
        plusUpgradeGO.SetActive(true);
    }

    void HidePlusUpgrade()
    {
        _uppies = false;
        plusUpgradeGO.SetActive(false);
    }

    private void Update()
    {
        if (_uppies)
        {
            Vector3 position = plusUpgradeGO.transform.position;
            position.y += Time.deltaTime * moveupSpeed;
            plusUpgradeGO.transform.position = position;
        } 
    }

    private void Awake()
    {
        GameEvents.OnPlayerBrakeClickable += GameEvents_OnPlayerBrakeClickable;
    }
    private void OnDisable()
    {
        GameEvents.OnPlayerBrakeClickable -= GameEvents_OnPlayerBrakeClickable;
    }

}
