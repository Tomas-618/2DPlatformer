using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _collectingSoundVolume;

    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;

    public void Init(AudioSource audioSource) =>
        _audioSource = audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            _audioSource.PlayOneShot(_clip, _collectingSoundVolume);
            Destroy(gameObject);
        }
    }
}
