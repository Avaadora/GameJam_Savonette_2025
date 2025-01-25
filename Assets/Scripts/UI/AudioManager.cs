using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _bgMusic;
    [SerializeField] private AudioClip _sfx1;
    [SerializeField] private AudioClip _sfx2;
    [SerializeField] private AudioClip _sfx3;
    [SerializeField] private AudioClip _sfx4;

    void Start()
    {
        _musicSource.clip = _bgMusic;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip sfx)
    {
        _sfxSource.PlayOneShot(sfx);
    }
}
