using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMissionScript : MonoBehaviour
{
    [Header("Buttons")]
    public Button missionStartButton;
    public Button missionOptonsButton;
    public Button missionReturnButton;

    [Header("Panels")]
    public GameObject startMissionPanel;
    public GameObject selectMissionPanel;
    public GameObject optionsPanel;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip clickSound;

    void OnEnable()
    {
        missionStartButton.onClick.AddListener(() => {
            PlayClickSound();
            StartMission();
        });
        missionOptonsButton.onClick.AddListener(() => {
            PlayClickSound();
            Options();
        });
        missionReturnButton.onClick.AddListener(() => {
            PlayClickSound();
            Return();
        });
    }

    public void StartMission()
    {
        if (GameSessionScript.Instance.selectedMission == 1)
            SceneManager.LoadScene("First");
        else if (GameSessionScript.Instance.selectedMission == 2)
            SceneManager.LoadScene("TestScene");
        else if (GameSessionScript.Instance.selectedMission == 3)
            SceneManager.LoadScene("TestScene");
        else if (GameSessionScript.Instance.selectedMission == 4)
            SceneManager.LoadScene("TestScene");
        else if (GameSessionScript.Instance.selectedMission == 5)
            SceneManager.LoadScene("TestScene");
        else
            Debug.Log("How tf did you get here?");
    }

    public void Options()
    {
        optionsPanel.SetActive(true);
    }

    public void Return()
    {
        selectMissionPanel.SetActive(true);
        startMissionPanel.SetActive(false);
    }

    void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
