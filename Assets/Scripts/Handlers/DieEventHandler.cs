using UnityEngine;

[RequireComponent(typeof(Physics2DOwner))]
public class DieEventHandler : HealthEventsHandler
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private LayerMask _onDieLayer;

    private Physics2DOwner _physics2DOwner;

    private void Start() =>
        _physics2DOwner = GetComponent<Physics2DOwner>();

    protected override void OnDie()
    {
        gameObject.layer = _onDieLayer;
        _physics2DOwner.Rigidbody2DInfo.isKinematic = true;
        _physics2DOwner.ColliderInfo.enabled = false;
        _audioSource.enabled = false;
        base.OnDie();
    }
}
