using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public int score;

    private void Start()
    {
        ResetScore();
    }

    public void IncrementScore()
    {
        score ++;
    }

    public void UpdateScore(int value)
    {
        score += value;
    }

    public void ResetScore()
    {
        score = 0;
    }

}
