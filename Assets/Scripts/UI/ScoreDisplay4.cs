using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay4 : MonoBehaviour
{
    public TextMeshProUGUI text;
    private GameManager4 gameManager4;

    // Start is called before the first frame update
    void Start()
    {
        gameManager4 = GameManager4.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameManager4.currentScore.ToString();
    }
}
