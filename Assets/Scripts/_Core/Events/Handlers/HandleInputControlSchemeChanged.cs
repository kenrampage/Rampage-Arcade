using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.Events;

public class HandleInputControlSchemeChanged : MonoBehaviour
{
    public UnityEvent onGamepadActivated;
    public UnityEvent onKBMActivated;

    [SerializeField] private InputActionAsset inputActionAsset;

    private void OnEnable()
    {
        InputUser.onChange += HandleInputUserChange;
    }

    private void OnDisable()
    {
        InputUser.onChange -= HandleInputUserChange;
    }

    private void Awake()
    {
        print("Starting Control Scheme: " + inputActionAsset.controlSchemes[0].name);
        InvokeEvent("KBM");
    }

    private void HandleInputUserChange(InputUser user, InputUserChange change, InputDevice device)
    {
        if (change == InputUserChange.ControlSchemeChanged)
        {
            print("Control Scheme changed to: " + user.controlScheme.Value.name);

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
