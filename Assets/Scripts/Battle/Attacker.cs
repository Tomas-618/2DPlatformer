using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private float _distance;

    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private LayerMask _layerMask;

    private Transform _transform;

    public RaycastHit2D HitInfo => Physics2D.Raycast(_transform.position, Direction, _distance, _layerMask);

    public Vector2 Direction => _spriteRenderer.flipX ? Vector2.left : Vector2.right;

    private void Awake() =>
        _transform = transform;

    public void Attack()
    {
        if (HitInfo == false)
            return;

        if (HitInfo.transform.TryGetComponent(out IDamagable target))
            target.TakeDamage(_damage);
    }
}
