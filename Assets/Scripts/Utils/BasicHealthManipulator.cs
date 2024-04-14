using TMPro;
using UnityEngine;

public class BasicHealthManipulator : MonoBehaviour
{
    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _healingValue;
    [SerializeField] private Health _target;

    public void Attack() =>
        _target.TakeDamage(GetValue(_damage.text));

    public void Heal() =>
        _target.Increase(GetValue(_healingValue.text));

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
