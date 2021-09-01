using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorBar : MonoBehaviour
{
    private GameManager5 gameManager5;

    private void Start()
    {
        gameManager5 = GameManager5.Instance;
    }

    // Destroys this game object on collision with any trigger
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager5.gameIsActive)
        {

            Destroy(other.gameObject);

            if (other.transform.tag != "Bad")
            {
                GameManager5.Instance.EndGame();
            }
        }

    }
}
