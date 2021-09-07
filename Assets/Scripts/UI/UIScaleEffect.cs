using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaleEffect : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector3 originalScale;

    [SerializeField] private float scaleAmount;
    [SerializeField] private float scaleSpeed;

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
