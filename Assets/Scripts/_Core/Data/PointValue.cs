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
        scoreKeeper.AddToScore(1);
    }

    public void UpdateScore()
    {
        scoreKeeper.AddToScore(value);
    }

}
