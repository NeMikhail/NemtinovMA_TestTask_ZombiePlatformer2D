using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _oneShotAudioSource;
    [SerializeField] private AudioClip _shootSound;
    [SerializeField] private AudioClip _stepSound;
    [SerializeField] private AudioClip _pickupSound;
    [SerializeField] private AudioClip _deathSound;


    private void Start()
    {
        StopSound();
    }

    public void StopSound()
    {
        _audioSource.Pause();
    }

    public void PlayShootSound()
    {
        StopSound();
        _audioSource.clip = _shootSound;
        _audioSource.Play();
    }

    public void PlayWalkingSound()
    {
        StopSound();
        _audioSource.clip = _stepSound;
        _audioSource.Play();
    }

    public void PlayPickUpSound()
    {
        _oneShotAudioSource.PlayOneShot(_pickupSound);
    }

    public void PlayDeathSound()
    {
        _oneShotAudioSource.PlayOneShot(_deathSound);
    }
}
