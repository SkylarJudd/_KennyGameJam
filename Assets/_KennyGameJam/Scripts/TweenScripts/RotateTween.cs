using DG.Tweening;
using UnityEngine;

public class RotateTween : MonoBehaviour
{
    [SerializeField] private bool _enabled;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float duration;

    [SerializeField] private bool _yoyo;
    [SerializeField] private Ease _easingType;

    private bool _isRunning;
    private Quaternion _cachedRotation;

    private void Start()
    {
        _cachedRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_enabled)
        {
            _isRunning = false;
            transform.rotation = _cachedRotation;
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

        TweenX.TweenRotation(transform, rotation, duration, _yoyo, _easingType);

        _isRunning = true;
    }
}
