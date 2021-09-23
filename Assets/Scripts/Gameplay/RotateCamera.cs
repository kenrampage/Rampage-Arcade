using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    public float horizontalInput;

    [SerializeField] private SOGameStateKeeper gameStateKeeper;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        }

    }
}
