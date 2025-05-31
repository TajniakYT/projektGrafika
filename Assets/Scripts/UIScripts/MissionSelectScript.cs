using UnityEngine;
using UnityEngine.UI;

public class MissionSelectScript : MonoBehaviour
{
    [Header("Buttons")]
    public Button selectMission1Button;
    public Button selectMission2Button;
    public Button selectMission3Button;
    public Button selectMission4Button;
    public Button selectMission5Button;
    public Button returnButton;

    [Header("Panels")]
    public GameObject selectMissionPanel;
    public GameObject startMissionPanel;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    SaveData data;

    private void OnEnable()
    {
        selectMission1Button.onClick.AddListener(() =>
        {
            PlayClickSound();
            SelectedMission1();
        });
        selectMission2Button.onClick.AddListener(() => {
            PlayClickSound();
            SelectedMission2();
        });
        selectMission3Button.onClick.AddListener(() => {
            PlayClickSound();
            SelectedMission3();
        });
        selectMission4Button.onClick.AddListener(() => {
            PlayClickSound();
            SelectedMission4();
        });
        selectMission5Button.onClick.AddListener(() => {
            PlayClickSound();
            SelectedMission5();
        });
        returnButton.onClick.AddListener(() => {
            PlayClickSound();
            ReturnToMenu();
        });
        data = SaveSystemScript.LoadFromSlot(SaveManagerScript.Instance.GetSlot());
        if (data != null)
        {
            Debug.Log("Wczytano poprawnie dla slot nr:");
            Debug.Log(SaveManagerScript.Instance.GetSlot());
        }
        else
            Debug.Log("Fuck");

        Button[] missionButtons = {
            selectMission1Button,
            selectMission2Button,
            selectMission3Button,
            selectMission4Button,
            selectMission5Button
        };

        for (int i = 0; i < missionButtons.Length; i++)
        {
            bool isUnlocked = i < data.unlockedLevels;

            missionButtons[i].interactable = isUnlocked;

            ColorBlock cb = missionButtons[i].colors;
            cb.normalColor = isUnlocked ? Color.white : Color.gray;
            missionButtons[i].colors = cb;
        }

    }

    public void SelectedMission1()
    {
        GameSessionScript.Instance.selectedMission = 1;
        startMissionPanel.SetActive(true);
        selectMissionPanel.SetActive(false);
    }

    public void SelectedMission2()
    {
        GameSessionScript.Instance.selectedMission = 2;
        startMissionPanel.SetActive(true);
        selectMissionPanel.SetActive(false);
    }

    public void SelectedMission3()
    {
        GameSessionScript.Instance.selectedMission = 3;
        startMissionPanel.SetActive(true);
        selectMissionPanel.SetActive(false);
    }

    public void SelectedMission4()
    {
        GameSessionScript.Instance.selectedMission = 4;
        startMissionPanel.SetActive(true);
        selectMissionPanel.SetActive(false);
    }

    public void SelectedMission5()
    {
        GameSessionScript.Instance.selectedMission = 5;
        startMissionPanel.SetActive(true);
        selectMissionPanel.SetActive(false);
    }

    public void ReturnToMenu()
    {
        selectMissionPanel.SetActive(false);
    }

    void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}