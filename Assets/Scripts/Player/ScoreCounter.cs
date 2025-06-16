using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    void Start()
    {
        scoreText.text = "Score: " + score;
    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
    public string GetScore()
    {
        return score.ToString();
    }
}
