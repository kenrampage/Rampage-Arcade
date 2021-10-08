using UnityEngine;

public class TriggerEventsInArray : MonoBehaviour
{
    [SerializeField] private UnityEventData[] unityEventData;

    public void InvokeEventByIndex(int i)
    {
        unityEventData[i].unityEvent?.Invoke();
        print(unityEventData[i].name + " Event Invoked by Index");
    }

    public void InvokeEventByName(string value)
    {
        foreach (var item in unityEventData)
        {
            if(item.name == value)
            {
                item.unityEvent?.Invoke();
                print(value + " Event Invoked by Name");
                break;
            }
        }
    }
}
