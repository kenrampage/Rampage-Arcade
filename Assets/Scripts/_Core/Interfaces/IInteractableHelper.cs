using UnityEngine.Events;
using UnityEngine;

public class IInteractableHelper : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent onInteract;

    public void Interact()
    {
        onInteract?.Invoke();
    }
}
