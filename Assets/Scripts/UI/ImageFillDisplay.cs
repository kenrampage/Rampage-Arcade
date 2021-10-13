using UnityEngine;
using UnityEngine.UI;

public class ImageFillDisplay : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private SOFloat value;


    // Update is called once per frame
    void Update()
    {
        float fillPerc = value.GetValue();
        
        image.fillAmount = fillPerc;
        image.color = Color.Lerp(endColor, startColor, fillPerc);
    }
}
