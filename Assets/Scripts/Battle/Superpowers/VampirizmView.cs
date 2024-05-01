using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(AudioSource))]
public class VampirizmView : MonoBehaviour
{
    [SerializeField] private Vampirism _entity;
    [SerializeField] private AudioClip[] _clips;

    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() =>
        _entity.ChangedState += ChangeState;

    private void OnDisable() =>
        _entity.ChangedState -= ChangeState;

    private void SetRandomClip()
    {
        int clipIndex = Random.Range(0, _clips.Length);

        _audioSource.clip = _clips[clipIndex];
        _audioSource.Play();
    }

    private void ChangeState(bool isActive)
    {
        _audioSource.enabled = isActive;
        _spriteRenderer.enabled = isActive;

        if (isActive)
            SetRandomClip();
    }
}
