using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper;

public class Vampirism : MonoBehaviour
{
    [SerializeField, Min(0)] private float _delay;
    [SerializeField, Min(0)] private float _deltaDelay;
    [SerializeField, Min(0)] private float _value;

    [SerializeField] private InterfaceReference<IIncreaser, MonoBehaviour> _owner;
    [SerializeField] private HitCheckerByCollider2D _checker;

    private Coroutine _coroutine;

    public IReadOnlyList<IDamagable> Targets => _checker.Targets;

    private void OnValidate()
    {
        if (_deltaDelay >= _delay)
            _deltaDelay = _delay - 1;
    }

    private void Reset() =>
        _delay = 6;

    private void Update() =>
        Activate();

    private void Activate()
    {
        if (Input.GetKeyDown(KeyCode.V) == false)
            return;

        if (Targets.Count == 0)
            return;

        if (_coroutine != null)
            return;

        _coroutine = StartCoroutine(Process(_delay, _deltaDelay, _value));
    }

    private IEnumerator Process(float delay, float deltaDelay, float value)
    {
        WaitForSeconds wait = new WaitForSeconds(deltaDelay);

        int iterationsCount = (int)(delay / deltaDelay);

        for (int i = 0; i < iterationsCount; i++)
        {
            DamageTargets(value);

            if (Targets.Count == 0)
            {
                _coroutine = null;

                yield break;
            }

            _owner.Value.Increase(value * Targets.Count);

            yield return wait;
        }

        _coroutine = null;
    }

    private void DamageTargets(in float value)
    {
        for (int i = 0; i < Targets.Count; i++)
            Targets[i].TakeDamage(value);
    }
}
