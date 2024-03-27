using UnityEngine;

[RequireComponent(typeof(MovementSound))]
public class ZombieSound : MonoBehaviour
{
    [SerializeField] private Zombie _entity;

    private MovementSound _movement;

    private void Awake() =>
        _movement = GetComponent<MovementSound>();

    private void Update() =>
        _movement.Play(_entity.IsRunning, _entity.IsStanding);
}
