using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Attacker : MonoBehaviour
{
    [SerializeField, Min(0)] private float _damage;
    [SerializeField, Min(0)] private float _distance;

    [SerializeField] private LayerMask _layerMask;

    private Transform _transform;
    private SpriteRenderer _spriteRenderer;

    public RaycastHit2D HitInfo => Physics2D.Raycast(_transform.position, Direction, _distance, _layerMask);

    public Vector2 Direction => _spriteRenderer.flipX ? Vector2.left : Vector2.right;

    private void Awake()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Attack()
    {
        if (HitInfo == false)
            return;

        if (HitInfo.transform.TryGetComponent(out Health target))
            target.TakeDamage(_damage);
    }
}
