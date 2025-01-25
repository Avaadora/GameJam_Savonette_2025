using UnityEngine;
using UnityEngine.SceneManagement;

public class louisUIScreenChange : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
