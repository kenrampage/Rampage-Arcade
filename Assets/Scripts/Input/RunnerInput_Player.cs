using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class RunnerInput_Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputActionMap inputActionMap;
    private InputAction runnerJump;

    [SerializeField] private UnityEvent onJumpStart;
    [SerializeField] private UnityEvent onJumpStop;

    private void Awake()
    {
        inputActionMap = inputActionAsset.FindActionMap("Runner");
        runnerJump = inputActionMap.FindAction("Jump");
    }

    private void OnEnable()
    {
        runnerJump.started += DoJumpStart;
        runnerJump.canceled += DoJumpStop;
    }

    private void OnDisable()
    {
        runnerJump.started -= DoJumpStart;
        runnerJump.canceled -= DoJumpStop;
    }

    private void DoJumpStart(InputAction.CallbackContext context)
    {
        onJumpStart?.Invoke();
    }

    private void DoJumpStop(InputAction.CallbackContext context)
    {
        onJumpStop?.Invoke();
    }

}
