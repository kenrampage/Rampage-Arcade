using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis2 : MonoBehaviour
{

    public Vector3 rotationSpeed;
    public bool rotateAlways;
    private GameManager2 gameManager2;

    private void Start()
    {
        gameManager2 = GameManager2.Instance;
    }

    private void Update()
    {
        if (rotateAlways)
        {
            this.transform.Rotate(rotationSpeed * Time.unscaledDeltaTime, Space.Self);
        }

    }

}
