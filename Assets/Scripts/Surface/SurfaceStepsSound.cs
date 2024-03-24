using System;
using UnityEngine;

[Serializable]
public struct SurfaceStepsSound
{
    [SerializeField, Range(-3, 3)] private float _sprintPitch;
    [SerializeField, Range(-3, 3)] private float _walkingPitch;
    [SerializeField, Range(0, 1)] private float _volume;

    [SerializeField] private SurfaceType _type;
    [SerializeField] private AudioClip _clip;

    public SurfaceType Type => _type;

    public AudioClip Clip => _clip;

    public float SprintPitch => _sprintPitch;

    public float WalkingPitch => _walkingPitch;

    public float Volume => _volume;
}
