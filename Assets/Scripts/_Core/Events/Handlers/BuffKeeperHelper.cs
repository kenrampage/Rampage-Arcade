using UnityEngine;
using UnityEngine.Events;

public class BuffKeeperHelper : MonoBehaviour
{
    [SerializeField] private SOBuffKeeper buffKeeper;
    [SerializeField] private bool countdownTimer;

    [SerializeField] private UnityEvent onBuffActivated;
    [SerializeField] private UnityEvent onBuffDeactivated;

    private void Start()
    {
        buffKeeper.ResetBuff();
    }

    private void Update()
    {
        if (countdownTimer)
        {
            buffKeeper.CountdownTimer();
        }
    }

    private void OnEnable()
    {
        buffKeeper.onBuffActivated += TriggerBuffActivated;
        buffKeeper.onBuffDeactivated += TriggerBuffDeactivated;
    }

    private void OnDisable()
    {
        buffKeeper.onBuffActivated -= TriggerBuffActivated;
        buffKeeper.onBuffDeactivated -= TriggerBuffDeactivated;
    }

    private void TriggerBuffActivated()
    {
        onBuffActivated?.Invoke();
    }

    private void TriggerBuffDeactivated()
    {
        onBuffDeactivated?.Invoke();
    }

}
