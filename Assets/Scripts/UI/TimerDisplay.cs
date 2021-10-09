using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private SOFloat timer;


    // Update is called once per frame
    void Update()
    {
        float fillPerc = timer.GetValue();
        
        image.fillAmount = fillPerc;
        image.color = Color.Lerp(endColor, startColor, fillPerc);
    }
}
