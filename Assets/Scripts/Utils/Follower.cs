using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Transform _transform;

    private void Start() =>
        _transform = transform;

    private void Update() =>
        Follow();

    private void Follow() =>
        _transform.position = _target.position;
}
