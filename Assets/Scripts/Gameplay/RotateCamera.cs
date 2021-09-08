using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    public float horizontalInput;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        }

    }
}
