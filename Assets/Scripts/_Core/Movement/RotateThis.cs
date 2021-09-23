using System;
using UnityEngine;

public class RotateThis : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    public Vector3 rotationSpeed;
    public bool rotateAlways;

    private void Update()
    {
        if (rotateAlways)
        {
            transform.Rotate(rotationSpeed * Time.unscaledDeltaTime, Space.Self);
        }
        else 
        { 
            transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        }

    }

}
