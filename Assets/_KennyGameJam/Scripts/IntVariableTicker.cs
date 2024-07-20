using Obvious.Soap;
using UnityEngine;
using KenneyJam.Enums;

namespace KenneyJam.UI
{
    public class IntVariableTicker : MonoBehaviour
    {
        [Header("Ticker Settings")]
        [SerializeField] private bool _isRunning = true; // To control whether the timer is running
        [SerializeField] private TickerState tickerState;

        [Header("VariableReferences")]
        [SerializeField] private FloatReference tickRate;
        [SerializeField] private IntReference current;
        [SerializeField] private IntReference decreaseRate;
        [SerializeField] private IntReference increaseRate;

        [SerializeField] private FloatReference _currentTime;

        void Start()
        {
            // Initialize the timer
            _currentTime.Value = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isRunning)
            {
                // Decrease the timer value over time
                _currentTime.Value += Time.deltaTime;
                
                if(decreaseRate > increaseRate)
                {
                    tickerState = TickerState.Decreasing;
                }
                else if(increaseRate > decreaseRate)
                {
                    tickerState = TickerState.Increasing;
                }
                else
                {
                    tickerState = TickerState.Idle;
                }

                if(_currentTime >= tickRate)
                {
                    switch (tickerState)
                    {
                        case TickerState.Decreasing:
                            Decrease();
                            _currentTime.Value = 0f;
                            break;
                        case TickerState.Increasing:
                            Increase();
                            _currentTime.Value = 0f;
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
            current.Value -= decreaseRate - increaseRate;

            if (current.Value <= 0)
            {
                GameMannager.instance.gameState = GameState.GameOver;
                _isRunning = false;
            }
        }

        // Method to update the FuelTotal value
        private void Increase()
        {
            current.Value += increaseRate - decreaseRate;
        }
    }

}

