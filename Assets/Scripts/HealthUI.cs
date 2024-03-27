using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthUI : MonoBehaviour
{
    private Health _entity;

    private void Awake() =>
        _entity = GetComponent<Health>();

    private void Update() =>
        Debug.Log(_entity.Value);
}
