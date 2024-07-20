using DG.Tweening;
using UnityEngine;

public static class TweenX
{
    public static void TweenNumbers(TMPro.TMP_Text _text, float _startValue, float _endValue, float _duration = 1f, Ease _ease = Ease.InOutSine, string _format = "F0")
    {
        DOTween.To(() => _startValue, x => _startValue = x, _endValue, _duration).SetEase(_ease).OnUpdate(() =>
        {
            _text.text = _startValue.ToString(_format);
        });
    }

    public static void TweenMainCamera(float _duration, float _strength)
    {
        Camera.main.DOShakePosition(_duration, _strength);
    }

    public static void TweenRotation(Transform _transform, Vector3 _rotation, float _duration, bool _pingPong = false, Ease _ease = Ease.InOutSine)
    {
        Vector3 fullRotation = _transform.eulerAngles + _rotation; // Add the desired rotation to the current rotation

        if (_pingPong)
        {
            _transform.DOLocalRotate(fullRotation, _duration, RotateMode.FastBeyond360).SetEase(_ease).SetLoops(-1, LoopType.Yoyo);
        }
        else
        {
            _transform.DOLocalRotate(fullRotation, _duration, RotateMode.FastBeyond360).SetEase(_ease);
        }
    }


    public static void StopTween(Transform _transform)
    {
        _transform.DOKill();
    }

}
