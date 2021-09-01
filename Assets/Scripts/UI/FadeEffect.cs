using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeEffect : MonoBehaviour
{

    public float moveSpeed;
    public float fadeSpeed;
    public TextMeshProUGUI text;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (text.alpha > 0)
        {
            text.alpha -= fadeSpeed;
            transform.Translate(Vector3.up * moveSpeed, Space.Self);
        }
        else if (text.alpha <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
