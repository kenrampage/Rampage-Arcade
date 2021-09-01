using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleRepeatX : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rectTransform.position.x <= 0)
        {
            rectTransform.position = startPos;
        }
    }
}
