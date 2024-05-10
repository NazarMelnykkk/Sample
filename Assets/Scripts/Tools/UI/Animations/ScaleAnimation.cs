using System.Collections;
using UnityEngine;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private float _scaleFactor = 1.2f;
    [SerializeField] private float _animationDuration = 1.0f;

    [SerializeField] private Vector3 originalScale = new Vector3(1, 1, 1);
    private Coroutine _animateScaleCoroutine;

    private void OnEnable()
    {
        _animateScaleCoroutine = StartCoroutine(AnimateScale());
    }

    private void OnDisable()
    {
        if (_animateScaleCoroutine != null)
        {
            StopCoroutine(_animateScaleCoroutine);
        }
    }
    private IEnumerator AnimateScale()
    {
        while (true)
        {
            transform.DOScale(originalScale * _scaleFactor, _animationDuration)
                .SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(_animationDuration);

            transform.DOScale(originalScale, _animationDuration)
                .SetEase(Ease.InOutSine);

            yield return new WaitForSeconds(_animationDuration);
        }
    }
}
