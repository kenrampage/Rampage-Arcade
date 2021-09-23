using UnityEngine;
using UnityEngine.Events;

public class HandleGamePauseToggled : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    [SerializeField] private UnityEvent onPauseToggled;
    
    private void OnEnable()
    {
        gameStateKeeper.onGamePauseToggled += HandleEvent;
    }

    private void OnDisable()
    {
        gameStateKeeper.onGamePauseToggled -= HandleEvent;
    }

    private void HandleEvent()
    {
        onPauseToggled?.Invoke();
    }
}
