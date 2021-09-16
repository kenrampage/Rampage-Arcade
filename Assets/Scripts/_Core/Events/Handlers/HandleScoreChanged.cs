using UnityEngine;
using UnityEngine.Events;

public class HandleScoreChanged : MonoBehaviour
{
    [SerializeField] private UnityEvent onScoreChanged;

    private void OnEnable()
    {
        ScoreKeeper.onScoreChanged += HandleEvent;
    }

    private void OnDisable()
    {
        ScoreKeeper.onScoreChanged -= HandleEvent;
    }

    public void HandleEvent(int i)
    {
        onScoreChanged?.Invoke();
    }
}
