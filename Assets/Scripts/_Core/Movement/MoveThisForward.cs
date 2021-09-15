using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThisForward : MonoBehaviour
{
    public float speed = 40f;

    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
    }
}
