using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UICanvasGroupFadeEffect : MonoBehaviour
{
    [SerializeField] private bool fadeCanvasInAtStart;
    [SerializeField] private bool fadeCanvasOutAtStart;
    [SerializeField] private float fadeOutTime = 1f;
    [SerializeField] private float fadeInTime = 1f;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        if (fadeCanvasInAtStart)
        {
            FadeCanvasIn();

        }
        else if (fadeCanvasOutAtStart)
        {
            FadeCanvasOut();
        }


    }

    public void FadeCanvasIn()
    {
        canvasGroup.alpha = 0;
        LeanTween.alphaCanvas(canvasGroup, 1, fadeInTime).setIgnoreTimeScale(true);
    }

    public void FadeCanvasOut()
    {
        canvasGroup.alpha = 1;
        LeanTween.alphaCanvas(canvasGroup, 0, fadeOutTime).setIgnoreTimeScale(true);
    }
}
