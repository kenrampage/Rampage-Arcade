using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GameStateKeeper", menuName = "Rampage Arcade/SOGameStateKeeper")]
public class SOGameStateKeeper : ScriptableObject
{
    public event Action<GameState> onGameStateChanged;
    public event Action onGamePauseToggled;

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

    public void SetGameState(GameState gameState)
    {
        CurrentGameState = gameState;
    }

    public void InitializeLevel()
    {
        SetGameState(GameState.LEVELSTART);
    }

    public void StartLevel()
    {
        SetGameState(GameState.GAMEACTIVE);
    }

    public void PauseLevel()
    {
        SetGameState(GameState.GAMEPAUSED);
    }

    public void EndLevel()
    {
        SetGameState(GameState.LEVELEND);
    }

    public void TransitionIn()
    {
        SetGameState(GameState.TRANSITIONIN);
    }

    public void TransitionOut()
    {
        SetGameState(GameState.TRANSITIONOUT);
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
