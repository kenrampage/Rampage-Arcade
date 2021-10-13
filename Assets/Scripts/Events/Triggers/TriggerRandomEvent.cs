using UnityEngine;
using UnityEngine.Events;

public class TriggerRandomEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent[] unityEvents;

    private int CalculateRandomIndex()
    {
        var i = Random.Range(0, unityEvents.Length);
        return i;
    }

    public void InvokeRandomEvent()
    {
        unityEvents[CalculateRandomIndex()]?.Invoke();
    }

}
