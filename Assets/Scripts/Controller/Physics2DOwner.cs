using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Physics2DOwner : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BoxCollider2D _collider;

    public Rigidbody2D Rigidbody2DInfo => _rigidbody2D;

    public BoxCollider2D ColliderInfo => _collider;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }
}
