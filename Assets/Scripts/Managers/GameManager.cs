using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static event Action<GameState> onGameStateChanged;
    public static event Action onGamePauseToggled;

    public GameState currentGameState;
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

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         TogglePause();
    //     }
    // }


    public void InitializeLevel()
    {
        CurrentGameState = GameState.LEVELSTART;
    }

    public void StartLevel()
    {
        CurrentGameState = GameState.GAMEACTIVE;
    }

    public void PauseLevel()
    {
        CurrentGameState = GameState.GAMEPAUSED;
    }

    public void EndLevel()
    {
        CurrentGameState = GameState.LEVELEND;
    }

    public void TransitionLevel()
    {
        CurrentGameState = GameState.TRANSITION;
    }

    public void TogglePause()
    {
        switch (CurrentGameState)
        {
            case GameState.GAMEACTIVE:
                PauseLevel();
                onGamePauseToggled?.Invoke();
                break;

            case GameState.GAMEPAUSED:
                StartLevel();
                onGamePauseToggled?.Invoke();
                break;

            default:
                break;
        }
    }

}
