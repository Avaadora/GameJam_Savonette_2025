using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.LoadMusic();

        // actualise l'�tat du curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame() // lance le premier level
    {
        audioManager.PlaySFX(audioManager.buttonUI);
        SceneManager.LoadScene("S_Level01");
    }

    public void ExitGame() // ferme le jeu
    {
        audioManager.PlaySFX(audioManager.buttonUI);
        Application.Quit();
        Debug.Log("Exit App");
    }
}