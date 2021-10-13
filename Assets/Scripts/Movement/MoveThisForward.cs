using UnityEngine;

public class MoveThisForward : MonoBehaviour
{
    public float speed = 40f;

    [SerializeField] private SOGameStateKeeper gameStateKeeper;

    private void FixedUpdate()
    {
        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }
    }
}
