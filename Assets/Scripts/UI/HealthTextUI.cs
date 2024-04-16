using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class HealthTextUI : BasicHealthUI
{
    [SerializeField] private IReadOnlyHealth _model;

    private TMP_Text _text;

    private void Start() =>
        _text = GetComponent<TMP_Text>();

    protected override void SetValue(float value) =>
        _text.text = $"{value}/{_model.MaxValue}";
}
