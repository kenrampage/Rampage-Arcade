using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    [SerializeField] private ScoreKeeper scoreKeeper;


    private void Awake()
    {
        if(scoreKeeper == null)
        {
            scoreKeeper = FindObjectOfType<ScoreKeeper>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        text.text = scoreKeeper.score.ToString();
    }
}
