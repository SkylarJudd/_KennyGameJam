using DG.Tweening;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    [SerializeField] private bool _enabled;
    [SerializeField] private Vector3 scale;
    [SerializeField] private float duration;

    [SerializeField] private bool _yoyo;
    [SerializeField] private Ease _easingType;
    [SerializeField] GameObject visuals;

    private bool _isRunning;
    private Vector3 _cachedScale;

    private void Start()
    {
        if(visuals == null)
        {
            visuals = gameObject;
        }

        _cachedScale = visuals.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_enabled)
        {
            _isRunning = false;
            visuals.transform.localScale = _cachedScale;
            TweenX.StopTween(visuals.transform);
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

        TweenX.TweenScale(visuals.transform, scale, duration, _yoyo, _easingType);

        _isRunning = true;
    }
}
