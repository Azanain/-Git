using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Sourses")]
    [SerializeField] private AudioSource _soundStep;
    [SerializeField] private AudioSource _soundHit;

    [Header("Clips")]
    [SerializeField] private AudioClip _stepClip;
    [SerializeField] private AudioClip _hitClip;

    private void SoundStepAnimEvent()
    {
        _soundStep.PlayOneShot(_stepClip);
    }
    public void StopSoundStep()
    {
        _soundStep.Stop();
    }
    public void SoundHit()
    {
        _soundHit.PlayOneShot(_stepClip);
    }
    public void StopSoundHit()
    {
        _soundHit.Stop();
    }
}
