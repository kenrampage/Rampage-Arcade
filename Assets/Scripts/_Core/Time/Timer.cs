using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private UnityEvent onTimerDone;

    public float currentTime;
    public float timePercent;
    [SerializeField] private float startTime;
    [SerializeField] private float targetTime;

    [SerializeField] private bool timerOn = false;
    [SerializeField] private bool timerCountDown = true;

    private void Awake()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (timerOn)
        {
            TimerProgress();
        }
    }

    public void TimerOn()
    {
        timerOn = true;
    }

    public void TimerOff()
    {
        timerOn = false;
    }

    public void TimerProgress()
    {
        if (timerCountDown)
        {
            TimerCountdown();
        }
        else
        {
            TimerCountUp();
        }
    }

    public void TimerCountdown()
    {
        currentTime -= Time.deltaTime;
        timePercent = (currentTime - targetTime)  / startTime;

        if (currentTime <= targetTime)
        {
            TimerDone();
        }

    }

    public void TimerCountUp()
    {
        currentTime += Time.deltaTime;
        timePercent = (currentTime - startTime) / targetTime;

        if (currentTime >= targetTime)
        {
            TimerDone();
        }

    }

    public void ResetTimer()
    {
        currentTime = startTime;
    }

    public void TimerDone()
    {
        ResetTimer();
        onTimerDone?.Invoke();
    }




}
