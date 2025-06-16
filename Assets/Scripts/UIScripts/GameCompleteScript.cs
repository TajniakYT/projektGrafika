using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameCompleteScript : MonoBehaviour
{
    public GameObject GameCompletePanel;
    public Button saveButton;
    public TMP_Text scoreText;
    public ScoreCounter scoreCounter;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    private void Start()
    {
        GameCompletePanel.SetActive(false);
        saveButton.onClick.AddListener(() => {
            PlayClickSound();
            SaveAndReturnToMenu();
        });
    }

    public void ShowGameCompletePanel()
    {
        GameCompletePanel.SetActive(true);
        scoreText.text = $"Score: {scoreCounter.GetScore()}";
        Time.timeScale = 0f;
    }

    private void SaveAndReturnToMenu()
    {
        // Pobierz slot
        int slot = SaveManagerScript.Instance.GetSlot();

        // Za³aduj istniej¹ce dane
        SaveData data = SaveSystemScript.LoadFromSlot(slot);
        if (data == null)
        {
            data = new SaveData();
        }

        // Zaktualizuj dane
        data.unlockedLevels = Mathf.Max(data.unlockedLevels, 2);
        SaveSystemScript.SaveToSlot(slot, data);

        // Wróæ do menu
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