using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.Events;


// A Player Input Component MUST exist in the scene somewhere to invoke the event this class subscribes to. 
// Generally it'll live on the Input Manager

public class HandleControlSchemeChanged : MonoBehaviour
{
    // [SerializeField] private InputActionAsset inputActionAsset;
    public UnityEvent onGamepadActivated;
    public UnityEvent onKBMActivated;

    private void OnEnable()
    {
        InputUser.onChange += HandleInputUserChange;
    }

    private void OnDisable()
    {
        InputUser.onChange -= HandleInputUserChange;
    }

    private void Start()
    {
        InvokeEvent("KBM");
    }

    private void HandleInputUserChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if (change == InputUserChange.ControlSchemeChanged)
        {
            InvokeEvent(user.controlScheme.Value.name);
        }
    }

    private void InvokeEvent(string name)
    {
        switch (name)
        {
            case ("Gamepad"):
                onGamepadActivated?.Invoke();
                break;

            case ("KBM"):
                onKBMActivated?.Invoke();
                break;

            default:
                break;
        }
    }

}
