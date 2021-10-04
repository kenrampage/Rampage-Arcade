using UnityEngine;
using UnityEngine.Events;

public class LoopingTimer : MonoBehaviour
{
    [SerializeField] private SOFloat multiplier;

    [SerializeField] private float changePerLoop;

    [SerializeField] private float initialStartTime;

    [SerializeField] private float minTime;
    [SerializeField] private float startTime;
    [SerializeField] private float currentTime;

    [SerializeField] private bool timerOn;

    [SerializeField] private UnityEvent onTimerDone;

    private void Awake()
    {
        timerOn = false;
    }

    private void Update()
    {
        TimerCountdown();
    }

    public void StartTimer()
    {
        startTime = initialStartTime;
        currentTime = startTime;
        timerOn = true;
    }

    public void ResetTimer()
    {

        if (startTime - (changePerLoop * multiplier.GetValue()) > minTime)
        {
            startTime -= changePerLoop * multiplier.GetValue();
        }
        else
        {
            startTime = minTime;
        }

        currentTime = startTime;

    }

    public void TimerDone()
    {
        ResetTimer();
        onTimerDone?.Invoke();
    }

    public void TimerCountdown()
    {
        if (timerOn)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                TimerDone();
            }
        }

    }
}
