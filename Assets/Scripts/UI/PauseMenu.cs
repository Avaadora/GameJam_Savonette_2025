using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool _isGamePaused = false;

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (_isGamePaused)
            {
                Resume(); 
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("S_MainMenu_Def");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit App");
    }
} 