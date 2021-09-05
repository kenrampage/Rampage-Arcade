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

    [SerializeField] private Timer timer;



    // Update is called once per frame
    void Update()
    {
        float fillPerc = timer.time / timer.baseTime;
        
        image.fillAmount = fillPerc;
        image.color = Color.Lerp(endColor, startColor, fillPerc);
    }
}
