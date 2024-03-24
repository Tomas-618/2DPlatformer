using UnityEngine;

public class ArrivePoint : MonoBehaviour
{
    public bool IsReached { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision) =>
        IsReached = collision.GetComponent<Zombie>();

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Zombie>())
            IsReached = false;
    }
}
