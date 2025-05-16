using UnityEngine;
using UnityEngine.UI;

public class LoadGameScript : MonoBehaviour
{
    [Header("Buttons")]
    public Button loadSlot1Button;
    public Button loadSlot2Button;
    public Button loadSlot3Button;
    public Button returnButton;

    [Header("UI Panels")]
    public GameObject loadGamePanel;
    //public GameObject emptySlotWarning;

    private void Start()
    {
        loadSlot1Button.onClick.AddListener(Button1Listener);
        loadSlot2Button.onClick.AddListener(Button2Listener);
        loadSlot3Button.onClick.AddListener(Button3Listener);
        returnButton.onClick.AddListener(ReturnToMainMenu);
    }

    public void Button1Listener()
    {
        OnSlotSelected(1);
    }

    public void Button2Listener()
    {
        OnSlotSelected(2);
    }

    public void Button3Listener()
    {
        OnSlotSelected(3);
    }

    public void ReturnToMainMenu()
    {
        loadGamePanel.SetActive(false);
    }

    public void OnSlotSelected(int slotIndex)
    {
        try
        {
            SaveData data = SaveSystemScript.LoadFromSlot(slotIndex);
            if (data == null)
            {
                ShowEmptyWarning();
            }
            else
            {
                LoadGame(data);
            }
        }
        catch
        {
            Debug.LogWarning($"Nie uda³o siê wczytaæ save'u w slocie {slotIndex}");
            ShowEmptyWarning();
        }
    }


    private void LoadGame(SaveData data)
    {
        Debug.Log($"Wczytano poziom: {data.level}, czas: {data.playTimeSeconds}");
        // Przeka¿ dane do GameManagera lub prze³aduj scenê
        // SceneManager.LoadScene("Level" + data.level);
    }

    private void ShowEmptyWarning()
    {
        //emptySlotWarning.SetActive(true);
        Invoke(nameof(HideEmptyWarning), 2f); // ukryj po 2 sek
    }

    private void HideEmptyWarning()
    {
        //emptySlotWarning.SetActive(false);
    }
}
