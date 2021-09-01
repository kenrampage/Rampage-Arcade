using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis1 : MonoBehaviour
{

    public Vector3 rotationSpeed;
    public bool rotateAlways;
    private GameManager1 gameManager1;

    private void Start()
    {
        gameManager1 = GameManager1.Instance;
    }

    private void Update()
    {
        if (gameManager1.gameIsActive || rotateAlways)
        {
            this.transform.Rotate(rotationSpeed * Time.unscaledDeltaTime, Space.Self);
        }

        

    }

}
