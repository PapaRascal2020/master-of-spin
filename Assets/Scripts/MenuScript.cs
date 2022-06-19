using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public int levelId;
    public void PlayGame()
    {
        SceneManager.LoadScene(levelId);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
