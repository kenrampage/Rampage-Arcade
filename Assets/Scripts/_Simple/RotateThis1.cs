using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThis1 : MonoBehaviour
{

    public Vector3 rotationSpeed;
    public bool rotateAlways;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager.CurrentGameState == GameManager.GameState.GAMEACTIVE || rotateAlways)
        {
            this.transform.Rotate(rotationSpeed * Time.unscaledDeltaTime, Space.Self);
        }

        

    }

}
