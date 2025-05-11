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

    void Start()
    {
        optionsPanel.SetActive(false);
        newGameButton.onClick.AddListener(NewGame);
        PlayButton.onClick.AddListener(Play);
        optionsButton.onClick.AddListener(ShowOptions);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void NewGame()
    {
        Debug.Log("Nowa gra...");
        SceneManager.LoadScene("TestScene");
    }

    public void Play()
    {
        Debug.Log("Wczytuj� gr�...");
        SceneManager.LoadScene("TestScene");
    }

    public void ShowOptions()
    {
        Debug.Log("Pokazuj� opcje.");
        if (optionsPanel != null)
            optionsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Wyj�cie z gry...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
