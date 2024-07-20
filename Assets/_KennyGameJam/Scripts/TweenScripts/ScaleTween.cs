using DG.Tweening;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    [SerializeField] private bool _enabled;
    [SerializeField] private Vector3 scale;
    [SerializeField] private float duration;

    [SerializeField] private bool _yoyo;
    [SerializeField] private Ease _easingType;

    private bool _isRunning;
    private Vector3 _cachedScale;

    private void Start()
    {
        _cachedScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_enabled)
        {
            _isRunning = false;
            transform.localScale = _cachedScale;
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

        TweenX.TweenScale(transform, scale, duration, _yoyo, _easingType);

        _isRunning = true;
    }
}
