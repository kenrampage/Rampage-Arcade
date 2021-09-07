using UnityEngine;
using UnityEngine.Events;

public class HandleGameStateChanged : MonoBehaviour
{
    [SerializeField] private UnityEvent onLevelStart;
    [SerializeField] private UnityEvent onGameActivated;
    [SerializeField] private UnityEvent onGamePaused;
    [SerializeField] private UnityEvent onLevelEnd;

    private void OnEnable()
    {
        GameManager.onGameStateChanged += HandleEvent;
    }

    private void OnDisable()
    {
        GameManager.onGameStateChanged -= HandleEvent;
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
                onLevelEnd?.Invoke();
                break;

            default:
                break;
        }
    }
}
