using UnityEngine;
using FMODUnity;

public class FMODPlayWithParameters : MonoBehaviour
{
    [SerializeField] private SOFMODParameterData fmodParameterData;

    [SerializeField] [EventRef] private string fmodEvent;
    [SerializeField] private string parameterName;
    [SerializeField] private bool ignoreSeekSpeed;
    [SerializeField] private bool startOnEnable;

    [SerializeField] private bool playAttached;
    [SerializeField] private GameObject attachTarget;

    private FMOD.Studio.EventInstance eventInstance;

    private void Update()
    {
        if (playAttached)
        {
            eventInstance.set3DAttributes(RuntimeUtils.To3DAttributes(attachTarget.transform.position));
        }
    }

    public void InitializeEvent()
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    private void OnEnable()
    {
        InitializeEvent();
        fmodParameterData.onValueUpdated += SetParameterByName;
        if (startOnEnable)
        {
            StartEvent();
        }
    }

    private void OnDisable()
    {
        ReleaseEvent();
        fmodParameterData.onValueUpdated -= SetParameterByName;
    }

    public void StartEvent()
    {
        eventInstance.start();
    }

    public void PauseEvent()
    {
        eventInstance.setPaused(true);
    }

    public void UnpauseEvent()
    {
        eventInstance.setPaused(false);
    }

    public void StopEventNoFadeout()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void StopEventWithFadeout()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void SetParameterByName(float value)
    {
        eventInstance.setParameterByName(parameterName, value);
    }

    public void ReleaseEvent()
    {
        eventInstance.release();
    }
}
