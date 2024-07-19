using Obvious.Soap;
using UnityEngine;
using KenneyJam.Enums;

namespace KenneyJam.UI
{
    public class OxygenBarTicker : MonoBehaviour
    {
        [SerializeField] private FloatVariable oxygenTotal;
        [SerializeField] private FloatVariable oxygenDecreaseRate;
        [SerializeField] private FloatVariable oxygenIncreaseRate;

        private float _currentTime;

        [SerializeField] private TickerState tickerState;

        private bool _isRunning = true; // To control whether the timer is running

        void Start()
        {
            // Initialize the timer
            _currentTime = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isRunning)
            {
                // Decrease the timer value over time
                _currentTime += Time.deltaTime;

                if(_currentTime >= 3f)
                {
                    switch (tickerState)
                    {
                        case TickerState.Decreasing:
                            DecreaseOxygen();
                            _currentTime = 0f;
                            break;
                        case TickerState.Increasing:
                            IncreaseOxygen();
                            _currentTime = 0f;
                            break;
                        case TickerState.Idle:
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        // Method to update the OxygenTotal value
        private void DecreaseOxygen()
        {
            oxygenTotal.Value -= 1.0f * oxygenDecreaseRate;
        }

        // Method to update the OxygenTotal value
        private void IncreaseOxygen()
        {
            oxygenTotal.Value += 1.0f * oxygenIncreaseRate;
        }
    }

}

