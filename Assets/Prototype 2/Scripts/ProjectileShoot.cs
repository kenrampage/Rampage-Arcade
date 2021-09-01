using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public Vector3 aimDirection;
    public Camera gameCamera;

    public ObjectPooler objectPooler;


    // Start is called before the first frame update
    void Start()
    {
        gameCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetAimDirection();

        }
    }

    // Calculates direction and angle between player and mouse
    public void SetAimDirection()
    {

        Vector3 mousePosition = gameCamera.ScreenToViewportPoint(Input.mousePosition);
        Vector3 playerPosition = gameCamera.WorldToViewportPoint(transform.position);

        aimDirection = (new Vector3(mousePosition.x - playerPosition.x, mousePosition.y - playerPosition.y, transform.position.z)).normalized;

    }

    public void FireProjectile()
    {

    }


}
