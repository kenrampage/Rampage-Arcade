using UnityEngine;

public class LaunchThisObject : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Vector3 direction;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;
    [SerializeField] private float minTorque;
    [SerializeField] private float maxTorque;
    [SerializeField] private bool launchOnAwake;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (launchOnAwake)
        {
            LaunchObject();
        }
    }

    public void LaunchObject()
    {
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());
    }

    private Vector3 RandomForce()
    {
        return direction * Random.Range(minForce, maxForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

}
