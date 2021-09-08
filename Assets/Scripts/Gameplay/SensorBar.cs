using UnityEngine;

public class SensorBar : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Destroys this game object on collision with any trigger
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.CurrentGameState == GameState.GAMEACTIVE)
        {

            Destroy(other.gameObject);

            if (other.transform.tag != "Bad")
            {
                gameManager.EndLevel();
            }
        }

    }
}
