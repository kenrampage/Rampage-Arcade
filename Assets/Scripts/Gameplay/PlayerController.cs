using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    private float speed = 20.0f;
    private float xRange = 20;
    public GameObject model;
    public float projectileHeight;

    public GameManager2 gameManager2;


    public Camera gameCamera;

    public ObjectPooler objectPooler;

    public Vector3 lookTarget;



    private void Start()
    {
        gameManager2 = GameManager2.Instance;
        gameCamera = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        SetAimDirection();

        if (gameManager2.gameIsActive)
        {

            if (Input.GetMouseButtonDown(0))
            {

                if (gameManager2.currentAmmo > 0)
                {
                    FireProjectile();
                    gameManager2.DecreaseAmmo();
                    gameManager2.sfxPlayer.PlaySoundEvent(4);
                }
                else
                {
                    gameManager2.sfxPlayer.PlaySoundEvent(5);
                    // Debug.Log("Out of Ammo!");
                }

            }

            if (Input.GetMouseButtonDown(1))
            {
                gameManager2.ResetAmmo();
                gameManager2.sfxPlayer.PlaySoundEvent(6);
            }

            // Check for left and right bounds
            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            // Player movement left to right
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * horizontalInput);

        }


    }


    // Calculates direction and angle between player and mouse
    public void SetAimDirection()
    {

        if (gameManager2.gameIsActive)
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                lookTarget = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);
                model.transform.LookAt(lookTarget);

            }

        }
    }

    public void FireProjectile()
    {
        // Instantiate(projectilePrefab, new Vector3(transform.position.x, projectileHeight, transform.position.z), model.transform.rotation);

        // No longer necessary to Instantiate prefabs


        // Get an object object from the pool
        GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true); // activate it
            pooledProjectile.transform.position = new Vector3(transform.position.x, projectileHeight, transform.position.z); // position it at player
            pooledProjectile.transform.rotation = model.transform.rotation;
            // pooledProjectile.transform.rotation = Quaternion.Euler(0, 0, 0);
            // pooledProjectile.GetComponent<Rigidbody>().AddForce(aimDirection,ForceMode.VelocityChange);
        }

    }

}
