using UnityEngine;

public class HealthMediator : MonoBehaviour
{
    [SerializeField] private Health _health;

    public Health HealthInfo => _health;
}
