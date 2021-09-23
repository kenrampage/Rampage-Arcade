using UnityEngine;
using UnityEngine.Events;

public class HandleGameStateChanged : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;

    [SerializeField] private UnityEvent onLevelStart;
    [SerializeField] private UnityEvent onGameActivated;
    [SerializeField] private UnityEvent onGamePaused;
    [SerializeField] private UnityEvent onLevelEnd;
    [SerializeField] private UnityEvent onTransition;

    private void OnEnable()
    {
        gameStateKeeper.onGameStateChanged += HandleEvent;
    }

    private void OnDisable()
    {
        gameStateKeeper.onGameStateChanged -= HandleEvent;
    }

    private void HandleEvent(GameState currentGameState)
    {
        switch (currentGameState)
        {
            case GameState.LEVELSTART:
                onLevelStart?.Invoke();
                break;

            case GameState.GAMEACTIVE:
                onGameActivated?.Invoke();
                break;

            case GameState.GAMEPAUSED:
                onGamePaused?.Invoke();
                break;

            case GameState.LEVELEND:
                print("Level End!");
                onLevelEnd?.Invoke();
                break;

            case GameState.TRANSITION:
                onTransition?.Invoke();
                break;

            default:
                break;
        }
    }
}
