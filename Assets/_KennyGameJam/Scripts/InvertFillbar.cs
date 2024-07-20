using KenneyJam.UI;
using UnityEngine;
using UnityEngine.UI;
using KenneyJam.Enums;

public class InvertFillbar : MonoBehaviour
{
    [SerializeField] private IntVariableTicker ticker;
    [SerializeField] private Image fillImage;

    // Update is called once per frame
    void Update()
    {
        if(ticker.tickerState == TickerState.Decreasing)
        {
            fillImage.fillOrigin = 1;
        }
        else if (ticker.tickerState == TickerState.Increasing)
        {
            fillImage.fillOrigin = 0;
        }
    }
}
