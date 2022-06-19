using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int sceneId;
    public float timeToSwitch;
    void Start()
    {
        Invoke("GoToNext", timeToSwitch);
    }

    void GoToNext()
    {
        SceneManager.LoadScene(sceneId);
    }
}
