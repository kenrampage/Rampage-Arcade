using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeEffect : MonoBehaviour
{
    [SerializeField] private bool startOpaque;
    [SerializeField] private GameObject panel;
    [SerializeField] private float fadeOutTime;
    [SerializeField] private float fadeInTime;

    private Image image;
    private RectTransform rectTransform;

    private float targetAlpha;

    private void Awake()
    {
        image = panel.GetComponent<Image>();
        rectTransform = panel.GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (startOpaque)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.g, 1);
            FadeIn();
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.g, 0);
        }
    }

    public void FadeIn()
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

    public void FadeOut()
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
