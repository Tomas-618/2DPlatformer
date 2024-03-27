using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(MovementSound))]
public class PlayerSound : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private MovementSound _movement;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movement = GetComponent<MovementSound>();
    }

    private void Update() =>
        _movement.Play(Input.GetKey(KeyCode.LeftShift), _rigidbody2D.velocity == Vector2.zero);
}
