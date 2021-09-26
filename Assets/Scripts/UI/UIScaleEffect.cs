using UnityEngine;

public class UIScaleEffect : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 originalScale;

    [SerializeField] private float scaleAmount = 1.05f;
    [SerializeField] private float scaleSpeed = .2f;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void Scale()
    {
        Vector3 newScale = new Vector3(originalScale.x * scaleAmount, originalScale.y * scaleAmount, originalScale.z * scaleAmount);
        LeanTween.scale(gameObject, newScale, scaleSpeed).setIgnoreTimeScale(true);
    }

    public void ScaleReset()
    {
        Vector3 newScale = new Vector3(originalScale.x, originalScale.y, originalScale.z);
        LeanTween.scale(gameObject, newScale, scaleSpeed).setIgnoreTimeScale(true);
    }

}
