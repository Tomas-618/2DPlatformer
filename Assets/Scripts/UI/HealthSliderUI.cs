using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderUI : BasicHealthUI
{
    private Slider _view;

    public Slider View => _view;

    private void Start() =>
        _view = GetComponent<Slider>();

    protected override void SetValue(float value) =>
        _view.value = value;
}
