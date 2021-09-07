using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15f;
    public float leftBound = -15;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }

    }

}
