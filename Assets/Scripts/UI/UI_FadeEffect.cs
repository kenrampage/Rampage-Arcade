using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FadeEffect : MonoBehaviour
{

    public bool startOpaque;
    public Image image;
    public RectTransform rectTransform;
    public float fadeInTime;

    private float targetAlpha;

    // Start is called before the first frame update
    void Start()
    {
        if (startOpaque)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.g, 1);
            FadeInEffect();
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.g, 0);
        }
    }

    public void FadeInEffect()
    {
        if (image.color.a == 1)
        {
            targetAlpha = 0;
        }
        else if (image.color.a == 0)
        {
            targetAlpha = 1;
        }

        LeanTween.alpha(rectTransform, targetAlpha, fadeInTime);

    }

    public void FadeOutEffect(float fadeOutTime)
    {
        if (image.color.a == 1)
        {
            targetAlpha = 0;
        }
        else if (image.color.a == 0)
        {
            targetAlpha = 1;
        }

        LeanTween.alpha(rectTransform, targetAlpha, fadeOutTime);
    }
}
