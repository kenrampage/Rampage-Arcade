using UnityEngine;

public class CameraFollowCar : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 rotationOffset;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    private Transform target;
    private bool followOn = false;

    private void Awake()
    {
        followOn = false;
    }

    public void SetFollowTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        followOn = true;
    }


    private void FixedUpdate()
    {
        if (followOn)
        {
            HandleTranslation();
            HandleRotation();
        }

    }



    void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);

    }

    void HandleRotation()
    {
        var direction = (target.position - rotationOffset) - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
