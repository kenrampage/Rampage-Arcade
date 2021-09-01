using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Image image;
    public Color startColor;
    public Color endColor;
    private GameManager1 gameManager1;



    private void Start()
    {
        gameManager1 = GameManager1.Instance;
    }
    // Update is called once per frame
    void Update()
    {
        float fillPerc = gameManager1.currentTime / gameManager1.roundTime;
        
        image.fillAmount = fillPerc;
        image.color = Color.Lerp(endColor, startColor, fillPerc);
    }
}
