using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int level = 1;
    public float playTimeSeconds = 0f;
    public float health = 100f;
    // Mo¿esz dodaæ wiêcej danych póŸniej
}

public static class SaveSystemScript
{
    public static string GetPathForSlot(int slot) =>
        Application.persistentDataPath + $"/save{slot}.json";

    public static void CreateEmptySave(int slot)
    {
        SaveData data = new SaveData(); // mo¿esz dodaæ domyœlne dane
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetPathForSlot(slot), json);
    }

    public static void SaveToSlot(int slot, SaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetPathForSlot(slot), json);
    }

    public static SaveData LoadFromSlot(int slot)
    {
        string path = GetPathForSlot(slot);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<SaveData>(json);
        }
        return null;
    }

    public static bool SaveExists(int slot)
    {
        return File.Exists(GetPathForSlot(slot));
    }
}