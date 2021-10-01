using UnityEngine;
using System;

[CreateAssetMenu(fileName = "BuffKeeper", menuName = "Rampage Arcade/SOBuffKeeper")]
public class SOBuffKeeper : ScriptableObject
{
    public bool buffOn = false;
    public float timerCurrent;
    public float timerPercent;
    public float timerMax;

    public Action onBuffActivated;
    public Action onBuffDeactivated;

    public void BuffOn()
    {
        if (!buffOn)
        {
            onBuffActivated?.Invoke();
        }

        buffOn = true;

    }

    public void BuffOff()
    {
        if (buffOn)
        {
            onBuffDeactivated?.Invoke();
        }
        buffOn = false;
    }

    public void ResetDuration()
    {
        timerCurrent = timerMax;
        timerPercent = 1f;
    }

    public void ResetBuff()
    {
        buffOn = false;
        ResetDuration();
    }

    public void CountdownTimer()
    {
        if (timerCurrent > 0 && buffOn)
        {
            timerCurrent -= Time.deltaTime;
            timerPercent = timerCurrent / timerMax;
        }

        if (timerCurrent <= 0 && buffOn)
        {
            BuffOff();
            ResetDuration();
            timerPercent = 1f;
        }
    }
}
