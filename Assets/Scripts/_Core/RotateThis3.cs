using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis3 : MonoBehaviour
{

    public Vector3 rotationSpeed;
    public bool rotateAlways;
    private GameManager3 gameManager3;

    private void Start()
    {
        gameManager3 = GameManager3.Instance;
    }

    private void Update()
    {
        if (rotateAlways)
        {
            this.transform.Rotate(rotationSpeed * Time.unscaledDeltaTime, Space.Self);
        }



    }

}
