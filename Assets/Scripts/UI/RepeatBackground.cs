using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private float loopPos;

    [SerializeField]
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = (GetComponent<BoxCollider>().size.x) / 2;
        loopPos = transform.position.x - repeatWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < loopPos)
        {
            transform.position = startPos;
        }
    }
}
