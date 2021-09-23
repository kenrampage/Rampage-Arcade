using UnityEngine;

public class AnimalCollision : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Barrier" && gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {
            print("Game Over");
            Destroy(this.gameObject);
            gameStateKeeper.EndLevel();
        }

    }

}
