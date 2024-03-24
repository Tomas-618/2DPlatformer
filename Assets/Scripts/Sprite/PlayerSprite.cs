using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSprite : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake() =>
        _spriteRenderer = GetComponent<SpriteRenderer>();

    private void Update() =>
        Flip(_spriteRenderer);

    private void Flip(SpriteRenderer spriteRenderer)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            spriteRenderer.flipX = false;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            spriteRenderer.flipX = true;
    }
}
