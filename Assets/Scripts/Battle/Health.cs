using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public readonly int MaxValue = 100;

    [SerializeField] private UnityEvent _died;
    [SerializeField] private UnityEvent<float> _damaged;
    [SerializeField] private UnityEvent<float> _onHealing;

    private float _value;

    public event UnityAction Died
    {
        add => _died.AddListener(value);
        remove => _died.RemoveListener(value);
    }

    public event UnityAction<float> Damaged
    {
        add => _damaged.AddListener(value);
        remove => _damaged.RemoveListener(value);
    }

    public event UnityAction<float> OnHealing
    {
        add => _onHealing.AddListener(value);
        remove => _onHealing.RemoveListener(value);
    }

    public float Value
    {
        get => _value;
        private set
        {
            if (value >= MaxValue)
                _value = MaxValue;
            else if (value <= 0)
                _value = 0;
            else
                _value = value;
        }
    }

    private void Start() =>
        _value = MaxValue;

    public void Increase(in float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(value.ToString());

        Value += value;
        _onHealing.Invoke(Value);
    }

    public void TakeDamage(in float value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(value.ToString());

        Value -= value;

        if (Value <= 0)
        {
            _died.Invoke();

            return;
        }

        _damaged.Invoke(Value);
    }
}
