using UnityEngine;

public class CursorLocked : MonoBehaviour
{
    private void Start() =>
        Cursor.lockState = CursorLockMode.Locked;
}
