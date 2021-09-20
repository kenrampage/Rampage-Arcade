using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable] public class OnCarTurn : UnityEvent<Vector2> { }
[System.Serializable] public class OnCarAccelerate : UnityEvent<float> { }

public class CarInputPlayer : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputActionMap inputActionMap;
    private InputAction carBrake;
    private InputAction carAccelerate;
    private InputAction carTurn;

    [SerializeField] private OnCarAccelerate onCarAccelerate;
    [SerializeField] private OnCarTurn onCarTurn;
    [SerializeField] private UnityEvent onCarBrakeStart;
    [SerializeField] private UnityEvent onCarBrakeStop;


    private void Awake()
    {
        // playerInputActions = new PlayerInputActions();
        inputActionMap = inputActionAsset.FindActionMap("Car");
        
        carTurn = inputActionMap.FindAction("Turn");
        carAccelerate = inputActionMap.FindAction("Accelerate");
        carBrake = inputActionMap.FindAction("Brake");
    }

    private void OnEnable()
    {
        carTurn.started += DoCarTurnStart;
        carTurn.canceled += DoCarTurnStop;
        carTurn.Enable();

        carAccelerate.started += DoCarAccelerateStart;
        carAccelerate.canceled += DoCarAccelerateStop;
        carAccelerate.Enable();

        carBrake.started += DoCarBrakeStart;
        carBrake.canceled += DoCarBrakeStop;
        carBrake.Enable();
    }

    private void OnDisable()
    {
        carTurn.started -= DoCarTurnStart;
        carTurn.canceled -= DoCarTurnStop;
        carTurn.Disable();

        carAccelerate.started -= DoCarAccelerateStart;
        carAccelerate.canceled -= DoCarAccelerateStop;
        carAccelerate.Disable();

        carBrake.started -= DoCarBrakeStart;
        carBrake.canceled -= DoCarBrakeStop;
        carBrake.Disable();
    }

    private void DoCarTurnStart(InputAction.CallbackContext context)
    {
        onCarTurn?.Invoke(context.ReadValue<Vector2>());
    }

    private void DoCarTurnStop(InputAction.CallbackContext context)
    {
        onCarTurn?.Invoke(new Vector2(0, 0));
    }

    private void DoCarAccelerateStart(InputAction.CallbackContext context)
    {
        onCarAccelerate?.Invoke(context.ReadValue<float>());
    }

    private void DoCarAccelerateStop(InputAction.CallbackContext context)
    {
        onCarAccelerate?.Invoke(0);
    }

    private void DoCarBrakeStart(InputAction.CallbackContext context)
    {
        onCarBrakeStart?.Invoke();
    }

    private void DoCarBrakeStop(InputAction.CallbackContext context)
    {
        onCarBrakeStop?.Invoke();
    }

    public void DisableInput()
    {
        inputActionMap.Disable();
    }

    public void EnableInput()
    {
        inputActionMap.Enable();
    }

    public void ToggleInput()
    {
        if (inputActionMap.enabled)
        {
            DisableInput();
        }
        else
        {
            EnableInput();
        }
    }


}
