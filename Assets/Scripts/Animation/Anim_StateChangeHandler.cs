using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_StateChangeHandler : MonoBehaviour
{

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameManager.onGameStateChanged += HandleGameStateChanged;
    }

    private void OnDisable()
    {
        GameManager.onGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameManager.GameState currentGameState)
    {
        switch (currentGameState)
        {
            case GameManager.GameState.LEVELSTART:
                PauseAnimation();
                break;

            case GameManager.GameState.GAMEACTIVE:
                StartAnimation();
                break;

            case GameManager.GameState.GAMEPAUSED:
                PauseAnimation();
                break;

            case GameManager.GameState.LEVELEND:
                PauseAnimation();
                break;

            default:
                break;
        }
    }

    private void PauseAnimation()
    {
        animator.enabled = false;
        print("Animation Stopped");
    }

    private void StartAnimation()
    {
        animator.enabled = true;
        print("Animation Started");
    }


}
