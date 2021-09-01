using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // public Vector3 startPos;
    // public float repeatWidth;

    [SerializeField]
    private float speed = .1f;
    
    [SerializeField]
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        
        // startPos = transform.position;
        // repeatWidth = (GetComponent<BoxCollider>().size.x * transform.localScale.x) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2 = new Vector2(material.GetTextureOffset("_MainTex").x + speed, material.GetTextureOffset("_MainTex").y);
        material.SetTextureOffset("_MainTex", vector2);
        // transform.Translate(Vector3.left * Time.deltaTime * speed);

        // if (transform.position.x < startPos.x - repeatWidth)
        // {
        //     transform.position = startPos;
        // }
    }
}
