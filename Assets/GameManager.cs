using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timer;
    public Text resultText;
    public Text bestTimeText;

    private float startTime;
    public float bestTime;
    public float timeElapsed;

    public GameObject completedGameHUD;
    public GameObject FailedScreen;

    public static GameManager instance;

    private void Awake() => instance = this;

    void Start()
    { 
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        timeElapsed =  currentTime - startTime;
        timer.text = "Time: " + timeElapsed.ToString("F2");
    }

    public void LevelComplete()
    {
        PauseGame();
        completedGameHUD.SetActive(true);
        resultText.text = "Elapsed Time: " + timeElapsed.ToString("F2");
        bestTimeText.text = "Best Time: " + bestTime.ToString("F2");
    }

    public void Death()
    {
        PauseGame();
        FailedScreen.SetActive(true);
    }

    public void ReloadLevel()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
