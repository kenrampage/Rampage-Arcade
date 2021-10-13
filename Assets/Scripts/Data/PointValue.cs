using UnityEngine;

public class PointValue : MonoBehaviour
{
    [SerializeField] private SOInteger score;
    public int value;

    public void IncrementScore()
    {
        score.IncrementValue();
    }

    public void AddToScore()
    {
        score.AddToValue(value);
    }

}
