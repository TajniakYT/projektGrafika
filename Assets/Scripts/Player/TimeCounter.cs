using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public TMP_Text timerText;
    private float timeElapsed;
    void Update()
    {
        timeElapsed += Time.deltaTime;
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = $"{seconds:000}";
    }
}
