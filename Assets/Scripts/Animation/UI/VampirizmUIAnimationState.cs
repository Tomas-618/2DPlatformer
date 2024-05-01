using UnityEngine;

[RequireComponent(typeof(Animator))]
public class VampirizmUIAnimationState : MonoBehaviour
{
    [SerializeField] private Vampirism _entity;

    private Animator _animator;

    private void OnEnable() =>
        _entity.ChangedState += SetActivityParameter;

    private void OnDisable() =>
        _entity.ChangedState -= SetActivityParameter;

    private void Start() =>
        _animator = GetComponent<Animator>();

    private void SetActivityParameter(bool isActive) =>
        _animator.SetBool(VampirizmUIAnimationParams.IsActive, isActive);
}
