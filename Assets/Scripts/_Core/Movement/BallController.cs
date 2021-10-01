using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private GameObject powerupIndicator;
    [SerializeField] private GameObject focalPoint;

    private Rigidbody playerRb;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 125f;

    [SerializeField] private float bounceStrengthBuffed = 15f;
    [SerializeField] private float bounceStrengthBase = 2f;
    [SerializeField, ReadOnly] private float bounceStrengthCurrent;

    private float moveInput;
    private float rotateInput;
    private float currentSpeed;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Start()
    {
        SetBounceStrengthBase();
    }

    void Update()
    {
        currentSpeed = playerRb.velocity.magnitude;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.transform.position - gameObject.transform.position;

            other.rigidbody.AddForce(awayFromPlayer * bounceStrengthCurrent, ForceMode.Impulse);
        }
    }

    public void Move()
    {
        playerRb.AddForce(focalPoint.transform.forward * moveInput * speed);
    }

    public void Rotate()
    {
        focalPoint.transform.Rotate(Vector3.up, rotateInput * rotationSpeed * Time.deltaTime);
    }

    public void SetMoveInput(Vector2 value)
    {
        moveInput = value.y;
    }

    public void SetRotateInput(Vector2 value)
    {
        rotateInput = value.x;
    }

    public void SetBounceStrengthBuffed()
    {
        bounceStrengthCurrent = bounceStrengthBuffed;
    }

    public void SetBounceStrengthBase()
    {
        bounceStrengthCurrent = bounceStrengthBase;
    }

}
