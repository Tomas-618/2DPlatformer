using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    [SerializeField, Range(0, 1)] private float _deltaColorValue;

    [SerializeField] private Color _onPointerEnterColor;
    [SerializeField] private Color _onPointerExitColor;
    [SerializeField] private Color _onPointerDownColor;

    private Coroutine _coroutine;
    private Image _image;

    public Color OnPointerExitColor => _onPointerExitColor;

    protected virtual void Reset()
    {
        _deltaColorValue = 0.05f;
        _onPointerEnterColor = Color.white;
        _onPointerExitColor = Color.white;
        _onPointerDownColor = Color.white;
    }

    private void Start() =>
        _image = GetComponent<Image>();

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeColor(_image.color, _onPointerEnterColor));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeColor(_image.color, GetNormalColor()));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeColor(_image.color, _onPointerDownColor));
    }

    public virtual void OnPointerClick(PointerEventData eventData) =>
        OnPointerEnter(eventData);

    protected virtual Color GetNormalColor() =>
        _onPointerExitColor;

    private IEnumerator ChangeColor(Color startColor, Color endColor)
    {
        float currentColorValue = 0;

        while (_image.color != endColor)
        {
            _image.color = Color.Lerp(startColor, endColor, currentColorValue += _deltaColorValue);

            yield return null;
        }
    }
}
