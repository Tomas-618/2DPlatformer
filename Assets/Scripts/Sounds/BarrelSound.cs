using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BarrelSound : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    private AudioSource _audioSource;

    private void Awake() =>
        _audioSource = GetComponent<AudioSource>();

    private void OnCollisionEnter2D(Collision2D collision) =>
        _audioSource.PlayOneShot(_clip);
}
