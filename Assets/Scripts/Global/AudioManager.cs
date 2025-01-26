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
        if (!MainTheme.isPlaying)
        {
            MainTheme.clip = slide;
            MainTheme.loop = true; // Boucle le son de marche
            MainTheme.Play();
        }
    }

    public void LoadMusic(){
        MainTheme.clip = mainTheme;
        MainTheme.Play();
    }

    public void StopWalkSound()
    {
        sfxSource.Stop();
    }
}