using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay2 : MonoBehaviour
{
    public TextMeshProUGUI text;
    private GameManager2 gameManager2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager2 = GameManager2.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameManager2.currentScore.ToString();
    }
}
