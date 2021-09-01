using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtonEffect : MonoBehaviour
{

    public RectTransform rectTransform;
    private Vector3 originalScale;
    public float scaleAmount;
    public float scaleSpeed;


    private void Start()
    {

        originalScale = rectTransform.localScale;

    }


    public void MouseOver()
    {
        LeanTween.scale(gameObject, new Vector3(originalScale.x * scaleAmount, originalScale.y * scaleAmount, originalScale.z * scaleAmount), scaleSpeed).setIgnoreTimeScale(true);


    }

    public void MouseExit()
    {
        LeanTween.scale(gameObject, new Vector3(originalScale.x, originalScale.y, originalScale.z), scaleSpeed).setIgnoreTimeScale(true);
    }


}
