using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [Header("Buttons")]
    public Button resumeButton;
    public Button restartButton;
    public Button optionsButton;
    public Button quitButton;

    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject optionsPanel;

    private bool isPaused = false;

    private void Start()
    {
        optionsPanel.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
        restartButton.onClick.AddListener(Restart);
        optionsButton.onClick.AddListener(OpenOptions);
        quitButton.onClick.AddListener(QuitToMainMenu);
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("Escape has been pressed");
                if (isPaused)
                    Resume();
                else
                    Pause();
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void OpenOptions()
    {
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // zawsze resetuj czas!
        SceneManager.LoadScene("MainMenu");
    }
}