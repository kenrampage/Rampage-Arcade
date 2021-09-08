using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    public float baseTime;
    [SerializeField] private bool timerOn;

    private GameManager gameManager;

    private void OnEnable()
    {
        GameManager.onGameStateChanged += HandleGameStateChanged;
        CarControllerC.onPickup += ResetTimer;
    }

    private void OnDisable()
    {
        GameManager.onGameStateChanged -= HandleGameStateChanged;
        CarControllerC.onPickup -= ResetTimer;
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        ResetTimer();
    }

    private void Update()
    {
        TimerCountdown();

        if (time <= 0)
        {
            ResetTimer();
            TimerOff();
            gameManager.CurrentGameState = GameState.LEVELEND;
        }
    }


    private void HandleGameStateChanged(GameState currentGameState)
    {

        switch (currentGameState)
        {
            case GameState.LEVELSTART:
                TimerOff();
                break;

            case GameState.GAMEACTIVE:
                TimerOn();
                break;

            case GameState.GAMEPAUSED:
                TimerOff();
                break;

            case GameState.LEVELEND:
                TimerOff();
                break;

            default:
                break;
        }

    }

    public void TimerCountdown()
    {
        if (timerOn)
        {
            time = time - Time.deltaTime;
        }

    }

    private void TimerOn()
    {
        timerOn = true;
    }

    private void TimerOff()
    {
        timerOn = false;
    }

    public void ResetTimer()
    {
        time = baseTime;
    }

}
