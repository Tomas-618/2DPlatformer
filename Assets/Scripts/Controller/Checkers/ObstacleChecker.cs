using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleChecker : MonoBehaviour
{
    private readonly RaycastHit2D[] _hitsInfo = new RaycastHit2D[1];

    [SerializeField, Min(0)] private float _distance;

    [SerializeField] private ContactFilter2D _filter;

    private Rigidbody2D _rigidbody2D;

    public RaycastHit2D HitInfo => _hitsInfo[0];

    private void Reset() =>
        _distance = 0.1f;

    private void Start() =>
        _rigidbody2D = GetComponent<Rigidbody2D>();

    public bool IsWayFree(in Vector2 direction) =>
        _rigidbody2D.Cast(direction, _filter, _hitsInfo, _distance) == 0;
}
