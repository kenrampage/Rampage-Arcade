using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] SOVector2 mousePosition;
    [SerializeField] SOVector2 gamepadDirection;
    private bool gamepadOn;

    [SerializeField] private List<GameObject> highlightedObjects = new List<GameObject>();

    private void FixedUpdate()
    {
        if (gamepadOn)
        {
            MoveCursor(gamepadDirection.value);
        }
        else
        {
            SetCursorPosition(mousePosition.value);
        }
    }

    public void SetCursorPosition(Vector2 value)
    {
        transform.position = value;
    }

    public void MoveCursor(Vector2 value)
    {
        transform.Translate(value * moveSpeed * Time.deltaTime);
    }

    public void SetGamepadState(bool value)
    {
        gamepadOn = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        highlightedObjects.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        highlightedObjects.Remove(other.gameObject);
    }

    public void Interact()
    {
        foreach (GameObject item in highlightedObjects.ToArray())
        {
            if (item.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact();
                highlightedObjects.Remove(item);
            }
        }

    }

}
