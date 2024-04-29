using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootStepsSound : MonoBehaviour
{
    [SerializeField] private SurfaceStepsSound[] _stepsSounds;
    [SerializeField] private HitCheckerByBoxCasting _groundChecker;
    
    private AudioSource _audioSource;
    private SurfaceType _currentSurfaceType;

    public SurfaceStepsSound CurrentSurfaceSound => _stepsSounds
        .First(sound => sound.Type == _currentSurfaceType);

    private void Awake() =>
        _audioSource = GetComponent<AudioSource>();

    private void Update()
    {
        RaycastHit2D hitInfo = _groundChecker.HitInfo;

        if (hitInfo == false)
            return;

        if (hitInfo.transform.TryGetComponent(out Surface surface) == false)
            return;

        if (surface.Type == _currentSurfaceType)
            return;

        SetSurfaceSteps(surface.Type);
    }

    public void Play() =>
        _audioSource.mute = false;

    public void Stop() =>
        _audioSource.mute = true;

    public void SetPitch(in bool isRunning) =>
        _audioSource.pitch = isRunning ? CurrentSurfaceSound.SprintPitch : CurrentSurfaceSound.WalkingPitch;

    private void SetSurfaceSteps(SurfaceType type)
    {
        _currentSurfaceType = type;

        _audioSource.clip = CurrentSurfaceSound.Clip;
        _audioSource.volume = CurrentSurfaceSound.Volume;
        _audioSource.Play();
    }
}
