using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    public Button newGameButton;
    public Button PlayButton;
    public Button optionsButton;
    public Button quitButton;

    [Header("UI Panels")]
    public GameObject optionsPanel;
    public GameObject newGamePanel;
    public GameObject loadGamePanel;
    public GameObject selectMissionPanel;
    public GameObject startMissionPanel;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    void Start()
    {
        optionsPanel.SetActive(false);
        newGamePanel.SetActive(false);
        loadGamePanel.SetActive(false);
        selectMissionPanel.SetActive(false);
        startMissionPanel.SetActive(false);
        newGameButton.onClick.AddListener(() => {
            PlayClickSound();
            NewGame();
        });
        PlayButton.onClick.AddListener(() => {
            PlayClickSound();
            Play();
        });
        optionsButton.onClick.AddListener(() => { PlayClickSound();
            ShowOptions();
        });
        quitButton.onClick.AddListener(() => {
            PlayClickSound();
            QuitGame();
        });
    }

    public void NewGame()
    {
        Debug.Log("Nowa gra...");
        if (newGamePanel != null)
            newGamePanel.SetActive(true);
    }

    public void Play()
    {
        Debug.Log("Wczytujê grê...");
        if (loadGamePanel != null)
            loadGamePanel.SetActive(true);
    }

    public void ShowOptions()
    {
        Debug.Log("Pokazujê opcje.");
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Wyjœcie z gry...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}