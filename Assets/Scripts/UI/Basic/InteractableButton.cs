using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InteractableButton : Interactable
{
    [SerializeField] private UnityEvent _onClick;

    public override void OnPointerClick(PointerEventData eventData)
    {
        _onClick.Invoke();
        base.OnPointerClick(eventData);
    }
}
