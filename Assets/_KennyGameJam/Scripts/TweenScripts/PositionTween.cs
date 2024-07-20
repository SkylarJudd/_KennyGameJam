using DG.Tweening;
using UnityEngine;

public class PositionTween : MonoBehaviour
{
    [SerializeField] private bool _enabled;
    [SerializeField] private Vector3 position;
    [SerializeField] private float duration;

    [SerializeField] private bool _yoyo;
    [SerializeField] private Ease _easingType;

    private bool _isRunning;
    private Vector3 _cachedPosition;

    private void Start()
    {
        _cachedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_enabled)
        {
            _isRunning = false;
            transform.position = _cachedPosition;
            TweenX.StopTween(transform);
            return;
        }
        else
        {
            TweenProcessing();
        }
    }

    void TweenProcessing()
    {
        if (_isRunning)
        {
            return;
        }

        TweenX.TweenPosition(transform, position, duration, _yoyo, _easingType);

        _isRunning = true;
    }
}
