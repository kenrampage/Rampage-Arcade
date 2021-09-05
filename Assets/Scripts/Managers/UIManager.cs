using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject startUI;
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject endUI;

    private void OnEnable()
    {
        GameManager.onGameStateChanged += UpdateUI;
    }

    private void OnDisable()
    {
        GameManager.onGameStateChanged -= UpdateUI;
    }

    private void UpdateUI(GameManager.GameState currentGameState)
    {
        switch (currentGameState)
        {
            case GameManager.GameState.LEVELSTART:
                StartUIOn();
                break;

            case GameManager.GameState.GAMEACTIVE:
                GameUIOn();
                break;

            case GameManager.GameState.GAMEPAUSED:
                PauseUIOn();
                break;

            case GameManager.GameState.LEVELEND:
                EndUIOn();
                break;

            default:
                break;
        }
    }


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
