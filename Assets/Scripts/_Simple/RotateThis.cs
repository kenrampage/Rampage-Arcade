using UnityEngine;

public class RotateThis : MonoBehaviour
{

    public Vector3 rotationSpeed;
    public bool rotateAlways;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (gameManager.CurrentGameState == GameManager.GameState.GAMEACTIVE || rotateAlways)
        {
            this.transform.Rotate(rotationSpeed * Time.unscaledDeltaTime, Space.Self);
        }

    }

}
