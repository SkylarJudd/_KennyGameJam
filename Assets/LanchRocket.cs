using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class LanchRocket : MonoBehaviour
{
    [SerializeField]
    private GameObject Rocket;
    [SerializeField]
    private float initialSpeed = 1f;
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float accelerationRate = 1.2f;
    [SerializeField]
    private float constantSpeedThreshold = 12f;

    private float currentSpeed;

    private void OnEnable()
    {
        GameEvents.OnGameWin += GameEvents_OnGameWin;
    }

    private void GameEvents_OnGameWin(GameObject obj)
    {
        StartCoroutine(LanchRocketLoop());
    }

    private void OnDisable()
    {
        GameEvents.OnGameWin -= GameEvents_OnGameWin;

    }

    IEnumerator LanchRocketLoop()
    {
        while (true)
        {
            if (currentSpeed < constantSpeedThreshold)
            {
                currentSpeed += accelerationRate * Time.deltaTime;
            }
            else if (currentSpeed < maxSpeed)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime);
            }
            else
            {
                currentSpeed = maxSpeed;
            }

            Vector3 rocketPosition = Rocket.transform.position;
            rocketPosition.y += currentSpeed * Time.deltaTime;
            Rocket.transform.position = rocketPosition;

            yield return null; // Yield execution until the next frame
        }
    }
}
