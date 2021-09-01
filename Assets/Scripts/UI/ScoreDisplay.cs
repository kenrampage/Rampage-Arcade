using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    private GameManager1 gameManager1;

    // Start is called before the first frame update
    void Start()
    {
        gameManager1 = GameManager1.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameManager1.currentScore.ToString();
    }
}
