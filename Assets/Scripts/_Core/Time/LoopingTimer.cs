using UnityEngine;
using UnityEngine.Events;

public class LoopingTimer : MonoBehaviour
{
    [SerializeField] private SOFloat changePerLoopMultiplier;
    [SerializeField] private bool useMultiplier;

    [SerializeField] private float changePerLoop;

    [SerializeField] private float initialStartTime;

    [SerializeField] private float minTime;
    private float startTime;
    private float currentTime;

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

    public void StopTimer()
    {
        timerOn = false;
    }

    public void ResetTimer()
    {
        if (useMultiplier)
        {
            if (startTime - (changePerLoop * changePerLoopMultiplier.GetValue()) > minTime)
            {
                startTime -= changePerLoop * changePerLoopMultiplier.GetValue();
            }
            else
            {
                startTime = minTime;
            }
        }
        else
        {
            if (startTime - changePerLoop > minTime)
            {
                startTime -= changePerLoop;
            }
            else
            {
                startTime = minTime;
            }
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
