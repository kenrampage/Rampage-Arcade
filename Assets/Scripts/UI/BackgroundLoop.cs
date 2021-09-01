using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoop : MonoBehaviour
{
    // Scroll main texture based on time

    [SerializeField]
    private float scrollSpeed = 0.5f;

    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

}
