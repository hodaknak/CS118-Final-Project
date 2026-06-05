using UnityEngine;
using UnityEngine.SceneManagement; // Required for managing scenes

public class SceneChanger : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Final Hallways");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
