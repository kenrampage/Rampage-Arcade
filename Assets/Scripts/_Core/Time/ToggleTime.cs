using UnityEngine;

public class ToggleTime : MonoBehaviour
{
    private float initialTimeScale;

    private void Awake()
    {
        initialTimeScale = Time.timeScale;
    }

    public void SetTimeScale(float scale)
    {
        Time.timeScale = scale;
    }

    public void EnableTime()
    {
        SetTimeScale(initialTimeScale);
    }

    public void DisableTime()
    {
        SetTimeScale(0);
    }

}
