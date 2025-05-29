using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompleteScript : MonoBehaviour
{
    public GameObject GameCompletePanel;
    public Button saveButton;

    private void Start()
    {
        GameCompletePanel.SetActive(false);
        saveButton.onClick.AddListener(SaveAndReturnToMenu);
    }

    public void ShowGameCompletePanel()
    {
        GameCompletePanel.SetActive(true);
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
}