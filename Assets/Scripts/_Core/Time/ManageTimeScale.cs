using UnityEngine;

public class ManageTimeScale : MonoBehaviour
{
    [SerializeField, ReadOnly] private float currentTimeScale;

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
        currentTimeScale = scale;
    }

    public void EnableTime()
    {
        SetTimeScale(1f);
        currentTimeScale = 1f;
    }

    public void DisableTime()
    {
        SetTimeScale(0);
        currentTimeScale = 0f;
    }



}
