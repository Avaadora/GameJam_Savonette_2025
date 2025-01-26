using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    private bool _musicOff = false;
    private bool _sfxOff = false;
    private float _musicLastValue;
    private float _sfxLastValue;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //if (PlayerPrefs.HasKey("musicVolume"))
        //{
        //    LoadVolume();
        //} else
        //{
        //    ChangeMusicVolume();
        //    ChangeSFXVolume();
        //}
    }

    public void ChangeMusicVolume()
    {
        float volume = _musicSlider.value;
        _mixer.SetFloat("music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void ChangeSFXVolume()
    {
        float volume = _sfxSlider.value;
        _mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }

    public void LoadVolume()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        _musicLastValue = _musicSlider.value;
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        _sfxLastValue = _sfxSlider.value;
    }

    public void TickMusic()
    {
        if (!_musicOff)
        {
            _musicLastValue = PlayerPrefs.GetFloat("musicVolume");
            _musicSlider.value = 0f;
            _musicOff = true;
        }
        else
        {
            _musicSlider.value = _musicLastValue;
            _musicOff = false;
        }
    }

    public void TickSFX()
    {
        if (!_sfxOff)
        {
            _sfxLastValue = PlayerPrefs.GetFloat("sfxVolume");
            _sfxSlider.value = 0f;
            _sfxOff = true;
        }
        else
        {
            _sfxSlider.value = _sfxLastValue;
            _sfxOff = false;
        }
    }

    public void TickFullScreen(bool fullscreen)
    {
        if (fullscreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        } else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("S_Level01_Def");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit App");
    }
}