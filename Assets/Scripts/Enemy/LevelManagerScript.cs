using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public GameCompleteScript gameCompleteScript;

    private void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0 || Input.GetKeyDown(KeyCode.Tab))
        {
            gameCompleteScript.ShowGameCompletePanel();
            enabled = false;
        }
    }
}