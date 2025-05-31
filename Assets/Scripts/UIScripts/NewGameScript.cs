using UnityEngine;
using UnityEngine.UI;

public class NewGameScript : MonoBehaviour
{
    [Header("Buttons")]
    public Button newSlot1Button;
    public Button newSlot2Button;
    public Button newSlot3Button;
    public Button returnButton;

    [Header("UI Panels")]
    public GameObject newGamePanel;
    public GameObject selectMissionPanel;
    //public GameObject confirmOverwritePanel;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    private int selectedSlot = -1;

    private void OnEnable()
    {
        newSlot1Button.onClick.AddListener(() => {
            PlayClickSound();
            Button1Listener();
        });
        newSlot2Button.onClick.AddListener(() => {
            PlayClickSound();
            Button2Listener();
        });
        newSlot3Button.onClick.AddListener(() => {
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
        newGamePanel.SetActive(false);
    }

    public void OnSlotSelected(int slotIndex)
    {
        if (SaveSystemScript.LoadFromSlot(slotIndex) != null)
        {
            selectedSlot = slotIndex;
            StartNewGame(slotIndex);
            //confirmOverwritePanel.SetActive(true); // zapytaj o potwierdzenie
        }
        else
        {
            StartNewGame(slotIndex);
        }
    }

    public void ConfirmOverwrite()
    {
        StartNewGame(selectedSlot);
        //confirmOverwritePanel.SetActive(false);
    }

    public void CancelOverwrite()
    {
        selectedSlot = -1;
        //confirmOverwritePanel.SetActive(false);
    }

    private void StartNewGame(int slot)
    {
        //GameTimer.Instance.ResetTimer();
        SaveSystemScript.CreateEmptySave(slot); // Tworzymy nowy plik zapisu

        Debug.Log($"Utworzono nowy zapis w slocie {slot}");
        SaveManagerScript.Instance.SetSlot(slot);
        selectMissionPanel.SetActive(true);
        newGamePanel.SetActive(false);
    }

    void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}