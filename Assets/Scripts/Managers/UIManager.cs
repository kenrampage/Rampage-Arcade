using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject endUI;

    // private void OnEnable()
    // {
    //     GameManager.onGameStateChanged += HandleGameStateChanged;
    // }

    // private void OnDisable()
    // {
    //     GameManager.onGameStateChanged -= HandleGameStateChanged;
    // }

    // private void HandleGameStateChanged(GameState currentGameState)
    // {
    //     switch (currentGameState)
    //     {
    //         case GameState.LEVELSTART:
    //             StartUIOn();
    //             break;

    //         case GameState.GAMEACTIVE:
    //             GameUIOn();
    //             break;

    //         case GameState.GAMEPAUSED:
    //             PauseUIOn();
    //             break;

    //         case GameState.LEVELEND:
    //             EndUIOn();
    //             break;

    //         default:
    //             break;
    //     }
    // }


    public void StartUIOn()
    {
        startUI.SetActive(true);
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);
    }

    public void GameUIOn()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        endUI.SetActive(false);
    }


    public void PauseUIOn()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
    }

    public void EndUIOn()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(true);
    }

}
