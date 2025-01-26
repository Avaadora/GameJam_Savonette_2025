using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // actualise l'état du curseur
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame() // lance le premier level
    {
        SceneManager.LoadScene("S_Level01_Def");
    }

    public void ExitGame() // ferme le jeu
    {
        Application.Quit();
        Debug.Log("Exit App");
    }
}