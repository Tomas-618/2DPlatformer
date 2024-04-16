using UnityEngine;

public class AttackerAnimationMediator : MonoBehaviour
{
    [SerializeField] private Attacker _entity;

    public void Attack() =>
        _entity.Attack();
}
