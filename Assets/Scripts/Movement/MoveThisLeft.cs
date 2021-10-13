using UnityEngine;

public class MoveThisLeft : MonoBehaviour
{
    public float speed = 15f;
    public float leftBound = -15;

    [SerializeField] private SOGameStateKeeper gameStateKeeper;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }

    }

}
