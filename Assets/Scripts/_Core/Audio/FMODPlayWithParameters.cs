using UnityEngine;
using FMODUnity;

public class FMODPlayWithParameters : MonoBehaviour
{
    [SerializeField] private SO_FMODParameterData fmodParameterData;

    [SerializeField] [EventRef] private string fmodEvent;
    [SerializeField] private string parameterName;
    [SerializeField] private bool ignoreSeekSpeed;
    [SerializeField] private bool playOnStart;

    [SerializeField] private bool playAttached;
    [SerializeField] private GameObject attachTarget;

    private FMOD.Studio.EventInstance eventInstance;

    private void Awake()
    {
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        if (playAttached)
        {
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(eventInstance, attachTarget.transform, attachTarget.GetComponent<Rigidbody>());

        }
    }

    private void OnEnable()
    {
        fmodParameterData.onValueUpdated += SetParameterByName;
    }

    private void OnDisable()
    {
        fmodParameterData.onValueUpdated -= SetParameterByName;
    }

    private void Start()
    {
        if (playOnStart)
        {
            StartEvent();
        }
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

    private void OnDestroy()
    {
        eventInstance.release();
    }
}
