using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UICanvasGroupFadeEffect : MonoBehaviour
{
    [SerializeField] private bool fadeAtStart;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private float fadeInTime = 1f;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        if (fadeAtStart)
        {
            if (canvasGroup.alpha == 1)
            {
                FadeOut();
            }
            else if (canvasGroup.alpha == 0)
            {
                FadeIn();
            }
            
        }
    }

    public void FadeIn()
    {
        LeanTween.alphaCanvas(canvasGroup, 1, fadeInTime).setIgnoreTimeScale(true);
    }

    public void FadeOut()
    {
        LeanTween.alphaCanvas(canvasGroup, 0, fadeOutTime).setIgnoreTimeScale(true);
    }
}
