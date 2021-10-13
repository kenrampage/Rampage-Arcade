using UnityEngine;

public class GameStateKeeper : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;

    private void Start()
    {
        gameStateKeeper.TransitionIn();
        gameStateKeeper.InitializeLevel();
    }

}
