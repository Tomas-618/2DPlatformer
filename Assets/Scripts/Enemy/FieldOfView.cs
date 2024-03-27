using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private ZombieSprite _sprite;
    [SerializeField] private Transform _target;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _layerMask;

    private Transform _transform;

    public bool IsSeeTarget { get; private set; }

    public Vector2 Direction => (_target.position - _transform.position).normalized;

    public RaycastHit2D HitInfo => Physics2D.Raycast(_transform.position, Direction, _distance, _layerMask);

    private void Reset() =>
        _distance = 20;

    private void Awake() =>
        _transform = transform;

    private void FixedUpdate()
    {
        if (HitInfo == false)
        {
            IsSeeTarget = false;

            return;
        }

        Transform hitTransform = HitInfo.transform;

        IsSeeTarget = hitTransform.TryGetComponent(out Player player) && _sprite.IsOnPositiveSideOfPlane(hitTransform.position);
    }
}
