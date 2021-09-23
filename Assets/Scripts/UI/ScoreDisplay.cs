using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField] private SOScoreKeeper scoreKeeper;

    // Update is called once per frame
    void Update()
    {
        text.text = scoreKeeper.Score.ToString();
    }
}
