using System.Collections.Generic;
using UnityEngine;
using AYellowpaper;

public class Vampirism : MonoBehaviour
{
    [SerializeField, Min(0)] private float _delay;
    [SerializeField, Min(0)] private float _value;

    [SerializeField] private InterfaceReference<IIncreaser, MonoBehaviour> _owner;
    [SerializeField] private HitCheckerByCollider2D _checker;

    private float _currentDelay;
    private bool _isActive;

    public List<Health> Targets => _checker.Targets;

    private void Reset() =>
        _delay = 6;

    private void Update() =>
        Activate();

    private void Activate()
    {
        if (Input.GetKeyDown(KeyCode.V) == false)
            return;

        if (_isActive)
            return;

        _isActive = true;

        while (_isActive)
        {
            Targets.ForEach(target => target.TakeDamage(_value));
            _owner.Value.Increase(_value * Targets.Count);

            _currentDelay += Time.deltaTime;
            _isActive = _currentDelay < _delay;
        }

        _currentDelay = 0;
    }
}
