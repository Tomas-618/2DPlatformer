using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupAlphaChanger : MonoBehaviour
{
    [SerializeField, Min(0)] private float _changingDeltaValue;

    private CanvasGroup _entity;

    private void Start() =>
        _entity = GetComponent<CanvasGroup>();

    public void Change(float value)
    {
        if (value <= 0)
            StartCoroutine(ChangeValue(value));
    }

    private IEnumerator ChangeValue(float desiredValue)
    {
        while (_entity.alpha != desiredValue)
        {
            _entity.alpha = Mathf.MoveTowards(_entity.alpha, desiredValue, _changingDeltaValue);

            yield return null;
        }
    }
}
