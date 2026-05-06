using UnityEngine;

public class SoundPlayer : ISoundPlayer
{
    private AudioSource _audioSource;
    private AudioClip _open;
    private AudioClip _close;

    public SoundPlayer(AudioSource source, AudioClip open, AudioClip close)
    {
        _audioSource = source;
        _open = open;
        _close = close;
    }

    public void PlayOpenSound()
    {
        _audioSource.PlayOneShot(_open);
    }

    public void PlayCloseSound()
    {
        _audioSource.PlayOneShot(_close);
    }
}