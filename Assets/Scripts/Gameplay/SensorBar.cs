using UnityEngine;

public class SensorBar : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;

    // Destroys this game object on collision with any trigger
    private void OnTriggerEnter(Collider other)
    {
        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {

            Destroy(other.gameObject);

            if (other.transform.tag != "Bad")
            {
                gameStateKeeper.EndLevel();
            }
        }

    }
}
