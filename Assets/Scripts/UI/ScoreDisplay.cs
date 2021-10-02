using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField] private SOInteger score;

    // Update is called once per frame
    void Update()
    {
        text.text = score.GetValue().ToString();
    }
}
