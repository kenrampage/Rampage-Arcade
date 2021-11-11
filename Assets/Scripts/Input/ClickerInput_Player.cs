using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ClickerInput_Player : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    private InputActionMap inputActionMap;
    private Camera mainCamera;

    private InputAction clickerMouseAim;
    private InputAction clickerGamepadAim;
    private InputAction clickerClick;

    [SerializeField] private SOVector2 mousePosition;
    [SerializeField] private SOVector2 gamepadDirection;
    [SerializeField] private UnityEvent onClick;

    private void Awake()
    {
        mainCamera = Camera.main;

        inputActionMap = inputActionAsset.FindActionMap("Clicker");

        clickerMouseAim = inputActionMap.FindAction("MouseAim");
        clickerGamepadAim = inputActionMap.FindAction("GamepadAim");
        clickerClick = inputActionMap.FindAction("Click");

    }

    private void OnEnable()
    {
        clickerClick.performed += DoClick;
    }

    private void OnDisable()
    {
        clickerClick.performed -= DoClick;
    }

    private void Update()
    {
        if (inputActionMap.enabled)
        {
            DoGamepadAim();
            DoMouseAim();
        }
    }

    private void DoClick(InputAction.CallbackContext context)
    {
        onClick?.Invoke();
    }


    private void DoMouseAim()
    {
        Ray ray = mainCamera.ScreenPointToRay(clickerMouseAim.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Background")))
        {
            mousePosition.value = new Vector3(raycastHit.point.x, raycastHit.point.y, 0);
        }
    }

    private void DoGamepadAim()
    {
        gamepadDirection.value = new Vector3(clickerGamepadAim.ReadValue<Vector2>().x, clickerGamepadAim.ReadValue<Vector2>().y, 0);
    }



}
