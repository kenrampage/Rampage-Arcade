using UnityEngine;
using UnityEngine.Events;

public class OnCollisionWithTag : MonoBehaviour
{
    [SerializeField] private UnityEvent onCollisionEnterEvent;
    [SerializeField] private UnityEvent onCollisionExitEvent;
    [SerializeField] private string collisionTag;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(collisionTag))
        {
            onCollisionEnterEvent?.Invoke();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag(collisionTag))
        {
            onCollisionExitEvent?.Invoke();
        }
    }

}
