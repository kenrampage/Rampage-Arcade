using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable] public class OnCarTurn : UnityEvent<Vector2> { }
[System.Serializable] public class OnCarAccelerate : UnityEvent<float> { }

public class CarInput_Player : MonoBehaviour
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
        inputActionMap = inputActionAsset.FindActionMap("Car");
        
        carTurn = inputActionMap.FindAction("Turn");
        carAccelerate = inputActionMap.FindAction("Accelerate");
        carBrake = inputActionMap.FindAction("Brake");
    }

    private void OnEnable()
    {
        carTurn.started += DoCarTurnStart;
        carTurn.canceled += DoCarTurnStop;

        carAccelerate.started += DoCarAccelerateStart;
        carAccelerate.canceled += DoCarAccelerateStop;

        carBrake.started += DoCarBrakeStart;
        carBrake.canceled += DoCarBrakeStop;
    }

    private void OnDisable()
    {
        carTurn.started -= DoCarTurnStart;
        carTurn.canceled -= DoCarTurnStop;

        carAccelerate.started -= DoCarAccelerateStart;
        carAccelerate.canceled -= DoCarAccelerateStop;

        carBrake.started -= DoCarBrakeStart;
        carBrake.canceled -= DoCarBrakeStop;
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


}
