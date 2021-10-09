using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private SOFMODParameterData ballSpeed;
    private Rigidbody playerRb;
    [SerializeField] private GameObject directionTarget;

    [SerializeField] private float speed = 5f;

    private float moveInput;
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
        playerRb.AddForce(directionTarget.transform.forward * moveInput * speed);
    }

    public void SetMoveInput(Vector2 value)
    {
        moveInput = value.y;
    }





}
