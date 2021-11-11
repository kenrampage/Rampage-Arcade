using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class SystemInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction systemPause;

    [SerializeField] private UnityEvent onSystemPause;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        systemPause = playerInputActions.System.Pause;

    }

    private void OnEnable()
    {
        systemPause.performed += DoSystemPause;
        systemPause.Enable();
    }

    private void OnDisable()
    {
        systemPause.performed -= DoSystemPause;
        systemPause.Disable();
    }

    private void DoSystemPause(InputAction.CallbackContext context)
    {
        onSystemPause?.Invoke();
    }

}
