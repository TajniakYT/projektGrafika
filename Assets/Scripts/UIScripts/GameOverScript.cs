using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{

    [Header("Buttons")]
    public Button restartButton;
    public Button returnButton;
    public Button quitButton;

    [Header("Panels")]
    public GameObject GameOverPanel;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    void Start()
    {
        GameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(() =>
        {
            PlayClickSound();
            Restart();
        });
        returnButton.onClick.AddListener(() =>
        {
            PlayClickSound();
            ReturnToMainMenu();
        });
        quitButton.onClick.AddListener(() =>
        {
            PlayClickSound();
            ReturnToMainMenu();
        });
    }

    public void ShowGameOverScreen()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}