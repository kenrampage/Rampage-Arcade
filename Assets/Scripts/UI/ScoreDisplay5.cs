using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay5 : MonoBehaviour
{
    public TextMeshProUGUI text;
    private GameManager5 gameManager5;

    // Start is called before the first frame update
    void Start()
    {
        gameManager5 = GameManager5.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameManager5.currentScore.ToString();
    }
}
