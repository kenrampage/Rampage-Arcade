using UnityEngine;
using UnityEngine.Events;

public class TriggerEventByChance : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;
    [SerializeField] bool onAwake;
    [SerializeField] bool onStart;
    [SerializeField] bool onEnable;
    [SerializeField] bool onDisable;
    [SerializeField] bool onDestroy;

    [SerializeField] [Range(0, 1)] float triggerChance;

    private bool CheckIfSuccessful()
    {
        if (Random.Range(0, 1) <= triggerChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TryTriggerEvent()
    {
        if (CheckIfSuccessful())
        {
            unityEvent?.Invoke();
        }
    }


    private void Awake()
    {
        if (onAwake)
        {
            TryTriggerEvent();
        }
    }

    private void Start()
    {
        if (onStart)
        {
            TryTriggerEvent();
        }
    }

    private void OnEnable()
    {
        if (onEnable)
        {
            TryTriggerEvent();
        }
    }

    private void OnDisable()
    {
        if (onDisable)
        {
            TryTriggerEvent();
        }
    }

    private void OnDestroy()
    {
        if (onDestroy)
        {
            TryTriggerEvent();
        }
    }
}
