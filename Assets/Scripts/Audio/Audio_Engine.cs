using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class Audio_Engine : MonoBehaviour
{

    public CarControllerC car;
    public StudioEventEmitter emitter;
    public float speedPerc;

    public float minRPM;
    public float maxRPM;
    public float currentRPM;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CurrentGameState == GameManager.GameState.GAMEACTIVE)
        {
            speedPerc = car.currentSpeed / car.maxSpeed;

            currentRPM = Mathf.Lerp(minRPM, maxRPM, speedPerc);
            emitter.SetParameter("RPM", currentRPM);
        }
        else
        {
            emitter.SetParameter("RPM", 0);
        }

    }
}
