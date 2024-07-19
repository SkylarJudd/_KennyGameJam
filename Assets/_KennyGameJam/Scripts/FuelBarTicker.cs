using Obvious.Soap;
using UnityEngine;
using KenneyJam.Enums;

namespace KenneyJam.UI
{
    public class FuelBarTicker : MonoBehaviour
    {
        [SerializeField] private FloatVariable fuelTotal;
        [SerializeField] private FloatVariable fuelDecreaseRate;
        [SerializeField] private FloatVariable fuelIncreaseRate;

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
                            Decrease();
                            _currentTime = 0f;
                            break;
                        case TickerState.Increasing:
                            Increase();
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

        // Method to update the FuelTotal value
        private void Decrease()
        {
            fuelTotal.Value -= 1.0f * fuelDecreaseRate;

            if (fuelTotal.Value <= 0.0f)
            {
                GameMannager.instance.gameState = GameState.GameOver;
                _isRunning = false;
            }
        }

        // Method to update the FuelTotal value
        private void Increase()
        {
            fuelTotal.Value += 1.0f * fuelIncreaseRate;
        }
    }

}

