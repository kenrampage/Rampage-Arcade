using UnityEngine;
using UnityEngine.Events;

public class OnObjectClicked : MonoBehaviour
{
    [SerializeField] private UnityEvent onObjectClicked;

    private void OnMouseDown()
    {
        onObjectClicked?.Invoke();
    }

}
