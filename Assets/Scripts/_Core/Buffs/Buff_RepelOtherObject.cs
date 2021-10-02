using UnityEngine;

public class Buff_RepelOtherObject : MonoBehaviour
{
    [SerializeField] private float bounceStrengthBuffed = 15f;
    [SerializeField] private float bounceStrengthBase = 2f;
    [SerializeField, ReadOnly] private float bounceStrengthCurrent;
    [SerializeField] private string targetTag;

    private void Start()
    {
        SetBounceStrengthBase();
    }

    [ContextMenu("Strength Buffed")]
    public void SetBounceStrengthBuffed()
    {
        bounceStrengthCurrent = bounceStrengthBuffed;
    }

    [ContextMenu("Strength Base")]
    public void SetBounceStrengthBase()
    {
        bounceStrengthCurrent = bounceStrengthBase;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            Rigidbody enemyRigidBody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 repelDirection = other.transform.position - gameObject.transform.position;

            other.rigidbody.AddForce(repelDirection * bounceStrengthCurrent, ForceMode.Impulse);
        }
    }

}
