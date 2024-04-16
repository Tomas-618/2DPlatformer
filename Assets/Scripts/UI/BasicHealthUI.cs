using UnityEngine;

public abstract class BasicHealthUI : MonoBehaviour
{
    [SerializeField] private Health _model;

    public Health Model => _model;

    private void OnEnable()
    {
        _model.Died += SetDieValue;
        _model.Damaged += SetValue;
        _model.OnHealing += SetValue;
    }

    private void OnDisable()
    {
        _model.Died -= SetDieValue;
        _model.Damaged -= SetValue;
        _model.OnHealing -= SetValue;
    }

    private void SetDieValue() =>
        SetValue(0);

    protected abstract void SetValue(float value);
}
