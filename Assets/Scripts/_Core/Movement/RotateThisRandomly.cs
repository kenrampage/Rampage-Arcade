using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateThisRandomly : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    private Vector3 rotationDirection;
    private float rotationSpeed;

    [SerializeField] private float rotationSpeedMin;
    [SerializeField] private float rotationSpeedMax;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rotationDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {
            transform.Rotate(rotationDirection * rotationSpeed, Space.Self);
        }

    }
}
