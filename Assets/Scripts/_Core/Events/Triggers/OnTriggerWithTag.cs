using UnityEngine;
using UnityEngine.Events;

public class OnTriggerWithTag : MonoBehaviour
{
    [SerializeField] private UnityEvent onTriggerEnterEvent;
    [SerializeField] private UnityEvent onTriggerExitEvent;
    [SerializeField] private string triggerTag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(triggerTag))
        {
            onTriggerEnterEvent?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(triggerTag))
        {
            onTriggerExitEvent?.Invoke();
        }
    }

}
