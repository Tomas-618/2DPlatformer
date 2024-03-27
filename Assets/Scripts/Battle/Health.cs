using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent _died;
    [SerializeField] private UnityEvent _damaged;

    public const int MaxValue = 100;

    private float _value;

    public float Value
    {
        get => _value;
        private set
        {
            if (value >= MaxValue)
            {
                _value = MaxValue;
            }
            else if (value <= 0)
            {
                _value = 0;
                _died.Invoke();
            }
            else
            {
                _value = value;
            }
        }
    }

    private void Start() =>
        _value = MaxValue;

    public void Increase(in float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(value.ToString());

        Value += value;
    }

    public void TakeDamage(in float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(value.ToString());

        Value -= value;

        if (Value > 0)
            _damaged.Invoke();
    }
}
