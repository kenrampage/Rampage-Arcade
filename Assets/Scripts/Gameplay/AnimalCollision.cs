using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    private GameManager gameManager;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Barrier" && gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {
            print("Game Over");
            Destroy(this.gameObject);
            gameManager.EndLevel();
        }

    }

}
