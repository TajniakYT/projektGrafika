using UnityEngine;

public class GameSessionScript : MonoBehaviour
{
    public static GameSessionScript Instance;

    public int selectedMission = -1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Utrzymaj miêdzy scenami
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
