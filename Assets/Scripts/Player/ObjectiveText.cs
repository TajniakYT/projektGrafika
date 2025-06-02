using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveText : MonoBehaviour
{
    public TMP_Text objectiveText;
    string objective = "destroy all enemies";

    // Start is called before the first frame update
    void Start()
    {
        objectiveText.text = "Objective: " + objective;
    }

}
