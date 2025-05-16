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

    void Start()
    {
        optionsPanel.SetActive(false);
        newGamePanel.SetActive(false);
        loadGamePanel.SetActive(false);
        newGameButton.onClick.AddListener(NewGame);
        PlayButton.onClick.AddListener(Play);
        optionsButton.onClick.AddListener(ShowOptions);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void NewGame()
    {
        Debug.Log("Nowa gra...");
        if (newGamePanel != null)
            newGamePanel.SetActive(true);
        //SceneManager.LoadScene("TestScene");
    }

    public void Play()
    {
        Debug.Log("Wczytujê grê...");
        if (loadGamePanel != null)
            loadGamePanel.SetActive(true);
        //SceneManager.LoadScene("TestScene");
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
}
