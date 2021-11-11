using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private SOFMODParameterData ballSpeed;
    [SerializeField] private SOVector2 ballMoveDirection;
    private Rigidbody playerRb;
    [SerializeField] private GameObject directionTarget;

    [SerializeField] private float speed = 5f;

    private float currentSpeed;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        currentSpeed = playerRb.velocity.magnitude;
        ballSpeed.FloatValue = currentSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        playerRb.AddForce(directionTarget.transform.forward * ballMoveDirection.value.y * speed);
    }

}
