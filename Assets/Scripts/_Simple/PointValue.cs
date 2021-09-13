using UnityEngine;

public class PointValue : MonoBehaviour
{
    private ScoreKeeper scoreKeeper;
    public int value;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void IncrementScore()
    {
        scoreKeeper.score++;
    }

    public void UpdateScore()
    {
        scoreKeeper.score += value;
    }

}
