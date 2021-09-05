using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        LEVELSTART,
        GAMEACTIVE,
        GAMEPAUSED,
        LEVELEND,
    }

    public static event Action<GameState> onGameStateChanged;
    private GameState currentGameState;
    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
        }
        set
        {
            currentGameState = value;
            onGameStateChanged?.Invoke(currentGameState);
        }
    }

    private void Start()
    {
        InitializeLevel();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }


    public void InitializeLevel()
    {
        CurrentGameState = GameState.LEVELSTART;
    }

    public void StartGame()
    {
        CurrentGameState = GameState.GAMEACTIVE;
    }

    public void PauseGame()
    {
        CurrentGameState = GameState.GAMEPAUSED;
    }

    public void EndLevel()
    {
        CurrentGameState = GameState.LEVELEND;
    }

    private void TogglePause()
    {
        switch (CurrentGameState)
        {
            case GameState.GAMEACTIVE:
                CurrentGameState = GameState.GAMEPAUSED;
                break;

            case GameState.GAMEPAUSED:
                CurrentGameState = GameState.GAMEACTIVE;
                break;

            default:
                break;
        }
    }

}
