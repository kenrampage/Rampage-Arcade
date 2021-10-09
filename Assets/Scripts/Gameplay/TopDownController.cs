using UnityEngine;
using UnityEngine.Events;

public class TopDownController : MonoBehaviour
{
    [SerializeField] private UnityEvent onFire;
    [SerializeField] private UnityEvent onFireEmpty;
    [SerializeField] private UnityEvent onReload;

    [SerializeField] private SOAmmoKeeper ammo;
    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject aimTarget;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileHeight;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float leftBounds;
    [SerializeField] private float rightBounds;

    private float moveDirection;

    private void Start()
    {
        ammo.ResetAmmo();
    }

    private void FixedUpdate()
    {
        SetLookDirection();
        Move();
    }

    public void Move()
    {

        if (transform.position.x < leftBounds)
        {
            transform.position = new Vector3(leftBounds, transform.position.y, transform.position.z);
        }

        if (transform.position.x > rightBounds)
        {
            transform.position = new Vector3(rightBounds, transform.position.y, transform.position.z);
        }

        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * moveSpeed * moveDirection);
    }

    public void SetMoveDirection(Vector2 value)
    {
        moveDirection = value.x;
    }

    public void Fire()
    {
        if (ammo.currentAmmo > 0)
        {
            // GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            // if (pooledProjectile != null)
            // {
            //     pooledProjectile.SetActive(true); // activate it
            //     pooledProjectile.transform.position = new Vector3(transform.position.x, projectileHeight, transform.position.z); // position it at player
            //     pooledProjectile.transform.rotation = playerModel.transform.rotation;

            // }

            Instantiate(projectile, new Vector3(transform.position.x, projectileHeight, transform.position.z), playerModel.transform.rotation);
            ammo.DecrementAmmo();
            onFire?.Invoke();
        }
        else if(ammo.currentAmmo <= 0)
        {
            onFireEmpty?.Invoke();
        }

    }

    public void Reload()
    {
        ammo.ResetAmmo();
        onReload?.Invoke();
    }

    public void SetLookDirection()
    {
        playerModel.transform.LookAt(aimTarget.transform);
    }
}
