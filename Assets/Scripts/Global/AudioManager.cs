using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource musicSource, sfxSource, MainTheme;


    [Header("Audio Clips")]
    public AudioClip mainTheme, mainMenu, jump, slide, buttonUI;

    void Start()
    {
        LoadMusic();
    }

    public void PlaySFX(AudioClip sfx)
    {
        sfxSource.PlayOneShot(sfx);
    }
    
    public void PlayWalkSound()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = slide;
            musicSource.loop = true; // Boucle le son de marche
            musicSource.Play();
        }
    }

    public void LoadMusic(){
        musicSource.clip = mainTheme;
        musicSource.Play();
    }

    public void StopWalkSound()
    {
        sfxSource.Stop();
    }
}