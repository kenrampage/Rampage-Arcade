using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ScoreKeeper", menuName = "Rampage Arcade/SOScoreKeeper")]
public class SOScoreKeeper : ScriptableObject
{
    public event Action<int> onScoreChanged;
    [SerializeField] private int score;
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
