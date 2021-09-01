using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    private GameManager2 gameManager2;

    private void Start()
    {
        gameManager2 = GameManager2.Instance;
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     print("Game Over");

    //     if (other.transform.tag == "Barrier")
    //     {
    //         print("Game Over");
    //         Destroy(this.gameObject);
    //         gameManager2.EndGame();
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "Barrier" && gameManager2.gameIsActive)
        {
            print("Game Over");
            Destroy(this.gameObject);
            gameManager2.EndGame();
        }

    }

}
