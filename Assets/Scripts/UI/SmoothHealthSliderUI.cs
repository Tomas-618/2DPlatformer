using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthSliderUI : HealthSliderUI
{
    [SerializeField, Min(0)] private float _changingDeltaValue;

    private Coroutine _coroutine;

    protected override void SetValue(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(value));
    }

    private IEnumerator ChangeValue(float desiredValue)
    {
        while (View.value != desiredValue)
        {
            base.SetValue(Mathf.MoveTowards(View.value, desiredValue, _changingDeltaValue));

            yield return null;
        }
    }
}
