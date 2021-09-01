using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis4 : MonoBehaviour
{

    public Vector3 rotationSpeed;
    public bool rotateAlways;
    private GameManager4 gameManager4;

    private void Start()
    {
        gameManager4 = GameManager4.Instance;
    }

    private void Update()

    {
        if (rotateAlways)
        {
            this.transform.Rotate(rotationSpeed * Time.unscaledDeltaTime, Space.Self);
        }

    }

}
