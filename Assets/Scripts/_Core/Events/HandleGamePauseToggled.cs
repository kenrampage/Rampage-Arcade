using UnityEngine;
using UnityEngine.Events;

public class HandleGamePauseToggled : MonoBehaviour
{
    [SerializeField] private UnityEvent onPauseToggled;

    private void OnEnable()
    {
        GameManager.onGamePauseToggled += HandleEvent;
    }

    private void OnDisable()
    {
        GameManager.onGamePauseToggled -= HandleEvent;
    }

    private void HandleEvent()
    {
        onPauseToggled?.Invoke();
    }
}
