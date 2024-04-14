using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderUI : MonoBehaviour
{
    [SerializeField, Min(0)] private float _changingDeltaValue;

    private Coroutine _coroutine;
    private Slider _view;

    private void Start() =>
        _view = GetComponent<Slider>();

    public void SetValue(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeValue(value));
    }

    private IEnumerator ChangeValue(float desiredValue)
    {
        while (_view.value != desiredValue)
        {
            _view.value = Mathf.MoveTowards(_view.value, desiredValue, _changingDeltaValue);

            yield return null;
        }
    }
}
