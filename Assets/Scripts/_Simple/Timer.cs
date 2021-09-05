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
        GameManager.onGameStateChanged += UpdateTimerState;
        CarControllerC.onPickup += ResetTimer;
    }

    private void OnDisable()
    {
        GameManager.onGameStateChanged -= UpdateTimerState;
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
            gameManager.CurrentGameState = GameManager.GameState.LEVELEND;
        }
    }


    private void UpdateTimerState(GameManager.GameState currentGameState)
    {

        switch (currentGameState)
        {
            case GameManager.GameState.LEVELSTART:
                TimerOff();
                break;

            case GameManager.GameState.GAMEACTIVE:
                TimerOn();
                break;

            case GameManager.GameState.GAMEPAUSED:
                TimerOff();
                break;

            case GameManager.GameState.LEVELEND:
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
