using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveTowardsTarget : MonoBehaviour
{
    private Rigidbody rigidBody;
    private GameObject followTarget;

    [SerializeField] private string targetTag;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        SetTargetByTag(targetTag);
    }

    private void FixedUpdate()
    {
        Move(CalcLookDirection());
    }

    private Vector3 CalcLookDirection()
    {
        return (followTarget.transform.position - transform.position).normalized;
    }

    private void Move(Vector3 lookDirection)
    {
        rigidBody.AddForce(lookDirection * speed);
    }

    public void SetTargetByTag(string tag)
    {
        followTarget = GameObject.FindGameObjectWithTag(tag);
    }
}
