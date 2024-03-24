using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ZombieSprite : MonoBehaviour
{
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private Plane _plane;

    private void Awake()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _plane = new Plane(Vector2.left, _transform.position);
    }

    public void SetTarget(in Vector2 position)
    {
        _plane.SetNormalAndPosition(Vector2.left, _transform.position);
        _spriteRenderer.flipX = _plane.GetSide(position);
    }
}
