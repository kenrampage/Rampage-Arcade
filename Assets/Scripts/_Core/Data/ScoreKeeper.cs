using UnityEngine;
using System;

public class ScoreKeeper : MonoBehaviour
{
    public static event Action<int> onScoreChanged;
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            
        }
    }

    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void UpdateScore(int i)
    {
        Score = i;
        onScoreChanged?.Invoke(score);
    }

    public void AddToScore(int i)
    {
        Score += i;
        onScoreChanged?.Invoke(score);
    }

}
