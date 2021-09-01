using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay3 : MonoBehaviour
{
    public TextMeshProUGUI text;
    private GameManager3 gameManager3;

    // Start is called before the first frame update
    void Start()
    {
        gameManager3 = GameManager3.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameManager3.currentScore.ToString();
    }
}
