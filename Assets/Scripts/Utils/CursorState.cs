using UnityEngine;
using UnityEngine.Events;

public class CursorState : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> _onChange;

    private bool _isCursorUnlocked;

    private void Start() =>
        Cursor.lockState = CursorLockMode.Locked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            _isCursorUnlocked = !_isCursorUnlocked;
            Cursor.lockState = _isCursorUnlocked ? CursorLockMode.None : CursorLockMode.Locked;

            _onChange.Invoke(_isCursorUnlocked);
        }
    }
}
