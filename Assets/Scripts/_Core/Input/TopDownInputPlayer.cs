using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[System.Serializable] public class OnTopDownMove : UnityEvent<Vector2> { }

public class TopDownInputPlayer : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private GameObject aimTarget;
    private Camera mainCamera;

    private InputActionMap inputActionMap;

    private InputAction topDownMove;
    private InputAction topDownFire;
    private InputAction topDownReload;
    private InputAction topDownMouseAim;
    private InputAction topDownGamepadAim;

    [SerializeField] private OnTopDownMove onTopDownMove;
    [SerializeField] private UnityEvent onTopDownFire;
    [SerializeField] private UnityEvent onTopDownReload;

    private bool gamepadOn;

    private void Awake()
    {
        mainCamera = Camera.main;

        inputActionMap = inputActionAsset.FindActionMap("TopDownShooter");

        topDownMove = inputActionMap.FindAction("Move");
        topDownFire = inputActionMap.FindAction("Fire");
        topDownReload = inputActionMap.FindAction("Reload");
        topDownMouseAim = inputActionMap.FindAction("MouseAim");
        topDownGamepadAim = inputActionMap.FindAction("GamepadAim");
    }

    private void OnEnable()
    {
        topDownMove.started += DoTopDownMoveStart;
        topDownMove.canceled += DoTopDownMoveStop;
        topDownFire.performed += DoTopDownFire;
        topDownReload.performed += DoTopDownReload;

    }

    private void OnDisable()
    {
        topDownMove.started -= DoTopDownMoveStart;
        topDownMove.canceled -= DoTopDownMoveStop;
        topDownFire.performed -= DoTopDownFire;
        topDownReload.performed -= DoTopDownReload;
    }

    private void DoTopDownMoveStart(InputAction.CallbackContext context)
    {
        onTopDownMove?.Invoke(context.ReadValue<Vector2>());
    }

    private void DoTopDownMoveStop(InputAction.CallbackContext context)
    {
        onTopDownMove?.Invoke(new Vector2(0, 0));
    }

    private void DoTopDownFire(InputAction.CallbackContext context)
    {
        onTopDownFire?.Invoke();
    }

    private void DoTopDownReload(InputAction.CallbackContext context)
    {
        onTopDownReload?.Invoke();
    }

    public void SetGamepadState(bool value)
    {
        gamepadOn = value;
    }

    private void Update()
    {
        if (inputActionMap.enabled)
        {
            if (gamepadOn)
            {
                DoGamepadAim();
            }
            else
            {
                DoMouseAim();
            }
        }
    }

    private void DoMouseAim()
    {
        Ray ray = mainCamera.ScreenPointToRay(topDownMouseAim.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            SetTargetPosition(new Vector3(raycastHit.point.x, 0 , raycastHit.point.z));
        }
    }

    private void DoGamepadAim()
    {
        SetTargetPosition(new Vector3(transform.position.x + topDownGamepadAim.ReadValue<Vector2>().x, 0, transform.position.z + topDownGamepadAim.ReadValue<Vector2>().y));
    }

    private void SetTargetPosition(Vector3 value)
    {
        aimTarget.transform.position = value;
    }

}
