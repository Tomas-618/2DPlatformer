using System.Collections.Generic;
using UnityEngine;

public class HitCheckerByCollider2D : MonoBehaviour
{
    private readonly List<Health> _targets = new List<Health>();

    [SerializeField] private LayerMask _layerMask;

    public List<Health> Targets => _targets;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health) == false)
            return;

        if (health.gameObject.layer != _layerMask)
            return;

        _targets.Add(health);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health health) == false)
            return;

        if (health.gameObject.layer != _layerMask)
            return;

        _targets.Remove(health);
    }
}
