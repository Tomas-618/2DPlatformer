using TMPro;
using UnityEngine;

public class BasicHealthManipulator : MonoBehaviour
{
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _healingValue;
    [SerializeField] private Health _target;

    public void Attack()
    {
        float damage = GetValue(_damage.text);

        if (damage == 0)
            return;

        _target.TakeDamage(damage);
    }

    public void Heal()
    {
        float healingValue = GetValue(_healingValue.text);

        if (healingValue == 0)
            return;

        _target.Increase(healingValue);
    }

    private float GetValue(string text)
    {
        if (text == string.Empty)
            return 0;

        float.TryParse(text.Remove(text.Length - 1), out float value);

        if (value <= 0)
            return 0;

        return value;
    }
}
