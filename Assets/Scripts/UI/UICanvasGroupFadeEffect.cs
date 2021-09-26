using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UICanvasGroupFadeEffect : MonoBehaviour
{
    [SerializeField] private bool fadeInAtStart;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private float fadeInTime = 1f;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        if (fadeInAtStart)
        {
            canvasGroup.alpha = 1;
            FadeIn();
            
        }
    }

    public void FadeIn()
    {
        canvasGroup.alpha = 1;
        LeanTween.alphaCanvas(canvasGroup, 0, fadeInTime).setIgnoreTimeScale(true);
    }

    public void FadeOut()
    {
        canvasGroup.alpha = 0;
        LeanTween.alphaCanvas(canvasGroup, 1, fadeOutTime).setIgnoreTimeScale(true);
    }
}
