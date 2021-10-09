using UnityEngine;
using UnityEngine.Events;

public class RepelOtherObject : MonoBehaviour
{
    [SerializeField] private SOFloat soTimerPercentage;
    [SerializeField] private float bounceStrengthBuffed = 15f;
    [SerializeField] private float bounceStrengthBase = 2f;
    [SerializeField] private float buffDuration;
    [SerializeField] private float currentDuration;

    [SerializeField] private bool buffOn;

    [SerializeField] private UnityEvent onBuffActivated;
    [SerializeField] private UnityEvent onBuffDeactivated;

    [SerializeField] private string targetTag;
    [SerializeField] private UnityEvent onBuffedCollision;
    [SerializeField] private UnityEvent onUnbuffedCollision;


    private void Start()
    {
        BuffOff();
        InitializeTimer();
    }

    private void Update()
    {
        CountdownTimer();
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
        Vector3 repelDirection = other.transform.position - gameObject.transform.position;

        if (other.gameObject.CompareTag(targetTag))
        {
            if (buffOn)
            {
                other.rigidbody.AddForce(repelDirection * bounceStrengthBuffed, ForceMode.Impulse);
                onBuffedCollision?.Invoke();
            }
            else
            {
                other.rigidbody.AddForce(repelDirection * bounceStrengthBase, ForceMode.Impulse);
                onUnbuffedCollision?.Invoke();
            }
        }
    }

    public void BuffOn()
    {
        buffOn = true;
        ResetTimer();
        onBuffActivated?.Invoke();
    }

    public void BuffOff()
    {
        buffOn = false;
        onBuffDeactivated?.Invoke();
    }

    private void CountdownTimer()
    {
        if (buffOn)
        {
            currentDuration -= Time.deltaTime;
            soTimerPercentage.SetValue(currentDuration / buffDuration);

            if (currentDuration <= 0)
            {
                BuffOff();
                
            }
        }
    }

    private void ResetTimer()
    {
        currentDuration = buffDuration;
    }

    private void InitializeTimer()
    {
        soTimerPercentage.SetValue(0);
    }   

}
