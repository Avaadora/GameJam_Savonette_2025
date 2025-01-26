using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject endGamePanel;
    private bool _isGamePaused = false;

    [SerializeField] private Slider destroySlider;
    [SerializeField] private Slider soapSlider;
    [SerializeField] private TextMeshProUGUI destroyedObjectsText;

    [SerializeField] private GameObject star01;
    [SerializeField] private GameObject star02;
    [SerializeField] private GameObject star03;

    private GameManager gameManager;


    private void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        destroySlider.value = (float)gameManager.destroyedObjectsNumber / (float)gameManager.destroyableObjectsNumber;
        soapSlider.value = 1f - gameManager.time / gameManager.soapTime;
        if (SceneManager.GetActiveScene().name != "S_Level02_Def" || Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            gameManager.time += Time.deltaTime;
        }
        if (gameManager.time >= gameManager.soapTime || gameManager.destroyedObjectsNumber == gameManager.destroyableObjectsNumber)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            gameplayPanel.SetActive(false);
            endGamePanel.SetActive(true);

            if (destroySlider.value >= 0.99f)
            {
                star01.SetActive(true);
                star02.SetActive(true);
                star03.SetActive(true);
            }
            else if (destroySlider.value >= 0.66f)
            {
                star01.SetActive(true);
                star02.SetActive(false);
                star03.SetActive(true);
            }
            else if (destroySlider.value >= 0.33f)
            {
                star01.SetActive(false);
                star02.SetActive(true);
                star03.SetActive(false);
            }
            else
            {
                star01.SetActive(false);
                star02.SetActive(false);
                star03.SetActive(false);

            }

            destroyedObjectsText.text = "Objects Destroyed:" + gameManager.destroyedObjectsNumber + " / " + gameManager.destroyableObjectsNumber;
        }

        if (Input.GetButtonDown("Pause") && (!tutorialPanel.activeSelf || endGamePanel))
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

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        tutorialPanel.SetActive(false);
        gameplayPanel.SetActive(true);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        _isGamePaused = false;
        pausePanel.SetActive(false);
        gameplayPanel.SetActive(true);
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        _isGamePaused = true;
        gameplayPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("S_MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("S_Level02");
    }
}