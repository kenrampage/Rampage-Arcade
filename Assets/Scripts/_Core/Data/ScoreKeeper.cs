using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public int score;

    private void Start()
    {
        ResetScore();
    }

    public void ResetScore()
    {
        score = 0;
    }

}
