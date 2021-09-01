using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis5 : MonoBehaviour
{

    public Vector3 rotationSpeed;
    public bool rotateAlways;
    private GameManager5 gameManager5;

    private void Start()
    {
        gameManager5 = GameManager5.Instance;
    }

    private void Update()
    {
        if (rotateAlways)
        {
            this.transform.Rotate(rotationSpeed * Time.unscaledDeltaTime, Space.Self);
        }

    
    }

}
