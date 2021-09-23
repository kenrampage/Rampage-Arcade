using UnityEngine;
using UnityEngine.Events;

public class HandleScoreChanged : MonoBehaviour
{
    [SerializeField] private SOScoreKeeper scoreKeeper;
    [SerializeField] private UnityEvent onScoreChanged;

    private void OnEnable()
    {
        scoreKeeper.onScoreChanged += HandleEvent;
    }

    private void OnDisable()
    {
        scoreKeeper.onScoreChanged -= HandleEvent;
    }

    public void HandleEvent(int i)
    {
        onScoreChanged?.Invoke();
    }
}
