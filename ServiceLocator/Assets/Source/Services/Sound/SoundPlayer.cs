using UnityEngine;
using Zenject;

public class SoundPlayer : ISoundPlayer
{
    private AudioSource _audioSource;
    private AudioClip _openClip;
    private AudioClip _closeClip;

    [Inject]
    public void Construct(AudioSource audioSource, [Inject(Id = "OpenClip")] AudioClip openClip, [Inject(Id = "CloseClip")] AudioClip closeClip)
    {
        _audioSource = audioSource;
        _openClip = openClip;
        _closeClip = closeClip;
    }

    public void PlayOpenSound()
    {
        _audioSource.PlayOneShot(_openClip);
    }

    public void PlayCloseSound()
    {
        _audioSource.PlayOneShot(_closeClip);
    }
}