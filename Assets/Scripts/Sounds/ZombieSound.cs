using UnityEngine;

[RequireComponent(typeof(MovementSound))]
public class ZombieSound : MonoBehaviour
{
    [SerializeField] private ZombieMovement _movement;

    private MovementSound _sound;

    private void Awake() =>
        _sound = GetComponent<MovementSound>();

    private void Update() =>
        _sound.Play(_movement.IsRunning, _movement.IsStanding);
}
