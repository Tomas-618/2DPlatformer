using UnityEngine;

public class HitCheckerByBoxCasting : MonoBehaviour
{
    [SerializeField, Min(0)] private float _offsetPositionY;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector2 _size;

    public RaycastHit2D HitInfo => Physics2D.BoxCast(GetGroundCheckerPosition(), _size, 0, Vector2.up, 0, _layerMask);

    private void OnDrawGizmosSelected() =>
        Gizmos.DrawCube(GetGroundCheckerPosition(), _size);

    private Vector2 GetGroundCheckerPosition()
    {
        Vector2 position = transform.position;

        position.y -= _offsetPositionY;

        return position;
    }
}
