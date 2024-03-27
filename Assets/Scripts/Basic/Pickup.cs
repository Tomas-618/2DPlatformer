using System;
using UnityEngine;

public abstract class Pickup<T> : Initializable<AudioSource>
{
    [SerializeField, Range(0, 1)] private float _collectingSoundVolume;

    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;

    public override void Init(AudioSource audioSource) =>
        _audioSource = audioSource ?? throw new ArgumentNullException(nameof(audioSource));

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsConditionTrueOnTriggerEnter(collision, out T behaviour))
        {
            _audioSource.PlayOneShot(_clip, _collectingSoundVolume);
            Destroy(gameObject);
            DoActionOnTriggerEnter(behaviour);
        }
    }

    protected abstract void DoActionOnTriggerEnter(T behaviour);

    protected abstract bool IsConditionTrueOnTriggerEnter(Collider2D collision, out T behaviour);
}

public abstract class Pickup : Initializable<AudioSource>
{
    [SerializeField, Range(0, 1)] private float _collectingSoundVolume;

    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;

    public override void Init(AudioSource audioSource) =>
        _audioSource = audioSource ?? throw new ArgumentNullException(nameof(audioSource));

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsConditionTrueOnTriggerEnter(collision))
        {
            _audioSource.PlayOneShot(_clip, _collectingSoundVolume);
            Destroy(gameObject);
        }
    }

    protected abstract bool IsConditionTrueOnTriggerEnter(Collider2D collision);
}
