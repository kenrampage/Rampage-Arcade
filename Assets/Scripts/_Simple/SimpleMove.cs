using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField]
    private Vector3 speed;

    void Update()
    {
        transform.position += speed;
    }
}
