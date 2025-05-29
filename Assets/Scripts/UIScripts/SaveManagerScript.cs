using UnityEngine;

public class SaveManagerScript : MonoBehaviour
{
    public static SaveManagerScript Instance;

    public int currentSaveSlot = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSlot(int slot)
    {
        currentSaveSlot = slot;
    }

    public int GetSlot()
    {
        return currentSaveSlot;
    }
}