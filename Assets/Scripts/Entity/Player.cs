using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnEnable() =>
        enabled = true;

    private void OnDisable() =>
        enabled = false;
}
