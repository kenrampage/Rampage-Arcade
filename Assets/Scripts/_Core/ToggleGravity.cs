using UnityEngine;

public class ToggleGravity : MonoBehaviour
{
    private Vector3 initialGravity;

    private void Awake()
    {
        initialGravity = Physics.gravity;
    }

    public void EnableGravity()
    {
        Physics.gravity = initialGravity;
    }

    public void DisableGravity()
    {
        Physics.gravity = new Vector3(0,0,0);
    }

}
