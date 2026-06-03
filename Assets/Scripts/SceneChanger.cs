using UnityEngine;
using UnityEngine.SceneManagement; // Required for managing scenes

public class SceneChanger : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Testing Assets Scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
