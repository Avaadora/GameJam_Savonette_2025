using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    private bool fullscreen = true;

    private void Start()
    {
        // actualise l'état du curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            ChangeMusicVolume();
            ChangeSFXVolume();
        }
    }

    public void LoadVolume() // charge les paramètres de volume
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    public void ChangeMusicVolume() // change le volume de la musique
    {
        float volume = _musicSlider.value;
        _mixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void ChangeSFXVolume() // change le volume des sfx
    {
        float volume = _sfxSlider.value;
        _mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void FullscreenToogle() // change le mode fullscreen du jeu
    {
        fullscreen = !fullscreen;
        Screen.fullScreenMode = fullscreen ? FullScreenMode.ExclusiveFullScreen : FullScreenMode.Windowed;
    }
}