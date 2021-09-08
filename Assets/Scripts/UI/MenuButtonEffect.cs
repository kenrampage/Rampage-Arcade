using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonEffect : MonoBehaviour
{

    public RectTransform rectTransform;
    private Vector3 originalScale;
    public float scaleAmount;
    public float scaleSpeed;

    public Texture thumbnail;
    public Texture originalThumbnail;
    public RawImage thumbnailTarget;

    // private void Start()
    // {
        
    //     originalThumbnail = thumbnailTarget.texture;
    //     thumbnailTarget.color = new Color(0, 0, 0, 0);
    //     originalScale = rectTransform.localScale;

    // }


    public void MouseOver()
    {
        // rectTransform.localScale = new Vector3(originalScale.x * scaleAmount, originalScale.y * scaleAmount, originalScale.z * scaleAmount);
        LeanTween.scale(gameObject, new Vector3(originalScale.x * scaleAmount, originalScale.y * scaleAmount, originalScale.z * scaleAmount), scaleSpeed);

        thumbnailTarget.color = new Color(1, 1, 1, 1);
        thumbnailTarget.texture = thumbnail;

    }

    public void MouseExit()
    {
        // rectTransform.localScale = originalScale;
        LeanTween.scale(gameObject, new Vector3(originalScale.x, originalScale.y, originalScale.z), scaleSpeed);


        thumbnailTarget.texture = originalThumbnail;
        thumbnailTarget.color = new Color(0, 0, 0, 0);
    }

}
