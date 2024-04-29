using System.Collections.Generic;
using UnityEngine;
using AYellowpaper;

public class Vampirism : MonoBehaviour
{
    private readonly List<Health> _targets = new List<Health>();

    [SerializeField, Min(0)] private float _delay;
    [SerializeField, Min(0)] private float _value;

    [SerializeField] private InterfaceReference<IIncreaser, MonoBehaviour> _owner;

    private float _currentDelay;
    private bool _isActive;

    private void Reset() =>
        _delay = 6;

    private void Start() =>
        _currentDelay = 0;

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
            _targets.ForEach(target => target.TakeDamage(_value));
            _owner.Value.Increase(_value * _targets.Count);

            _currentDelay += Time.deltaTime;
            _isActive = _currentDelay < _delay;
        }

        _currentDelay = 0;
    }
}
