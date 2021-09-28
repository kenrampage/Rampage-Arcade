﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownControllerOld : MonoBehaviour
{
    public float horizontalInput;
    private float speed = 20.0f;
    private float xRange = 20;
    public float projectileHeight;

    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    // [SerializeField] private Ammo ammo;
    [SerializeField] private GameObject playerModel;
    // [SerializeField] private FMODPlayOneShot sfxPlayer;


    public ObjectPooler objectPooler;
    public GameObject lookTarget;

    


    // Update is called once per frame
    void Update()
    {
        SetLookDirection();

        if (gameStateKeeper.CurrentGameState == GameState.GAMEACTIVE)
        {

            if (Input.GetMouseButtonDown(0))
            {

                // if (ammo.currentAmmo > 0)
                // {
                //     FireProjectile();
                //     // ammo.DecreaseAmmo();
                //     // sfxPlayer.PlaySoundEvent(4);
                // }
                // else
                // {
                //     // sfxPlayer.PlaySoundEvent(5);
                //     // Debug.Log("Out of Ammo!");
                // }

            }

            if (Input.GetMouseButtonDown(1))
            {
                // ammo.ResetAmmo();
                // sfxPlayer.PlaySoundEvent(6);
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




    private void SetLookDirection()
    {
        playerModel.transform.LookAt(new Vector3(lookTarget.transform.position.x, playerModel.transform.position.y, lookTarget.transform.position.z));
    }

    public void FireProjectile()
    {
        // Get an object object from the pool
        GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
        if (pooledProjectile != null)
        {
            pooledProjectile.SetActive(true); // activate it
            pooledProjectile.transform.position = new Vector3(transform.position.x, projectileHeight, transform.position.z); // position it at player
            pooledProjectile.transform.rotation = playerModel.transform.rotation;

        }

    }

}