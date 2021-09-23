using UnityEngine;

public class PointValue : MonoBehaviour
{
    [SerializeField] private SOScoreKeeper scoreKeeper;
    public int value;

    public void IncrementScore()
    {
        scoreKeeper.AddToScore(1);
    }

    public void UpdateScore()
    {
        scoreKeeper.AddToScore(value);
    }

}
