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
    public GameObject selectMissionPanel;
    //public GameObject emptySlotWarning;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    private void OnEnable()
    {
        loadSlot1Button.onClick.AddListener(() =>
        {
            PlayClickSound();
            Button1Listener();
        });
        loadSlot2Button.onClick.AddListener(() => {
            PlayClickSound();
            Button2Listener();
        });
        loadSlot3Button.onClick.AddListener(() => {
            PlayClickSound();
            Button3Listener();
        });
        returnButton.onClick.AddListener(() => {
            PlayClickSound();
            ReturnToMainMenu();
        });
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
                LoadGame(data, slotIndex);
            }
        }
        catch
        {
            Debug.LogWarning($"Nie uda³o siê wczytaæ save'u w slocie {slotIndex}");
            ShowEmptyWarning();
        }
    }


    private void LoadGame(SaveData data, int slotIndex)
    {
        Debug.Log($"Wczytano poziom: {data.unlockedLevels}, czas: {data.playTimeSeconds}");
        SaveManagerScript.Instance.SetSlot(slotIndex);
        selectMissionPanel.SetActive(true);
        loadGamePanel.SetActive(false);
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

    void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
