using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandomly : MonoBehaviour
{
    private GameManager gameManager;
    private Vector3 rotationDirection;
    private float rotationSpeed;

    [SerializeField] private float rotationSpeedMin;
    [SerializeField] private float rotationSpeedMax;
    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        rotationDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.CurrentGameState == GameManager.GameState.GAMEACTIVE)
        {
            transform.Rotate(rotationDirection * rotationSpeed, Space.Self);
        }

    }
}
