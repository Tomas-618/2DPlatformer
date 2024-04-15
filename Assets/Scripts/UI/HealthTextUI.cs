using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthTextUI : MonoBehaviour
{
    [SerializeField] private Health _model;

    private TMP_Text _text;

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

    private void Start() =>
        _text = GetComponent<TMP_Text>();

    private void SetValue(float health) =>
        _text.text = $"{health}/{_model.MaxValue}";

    private void SetDieValue() =>
        SetValue(0);
}
