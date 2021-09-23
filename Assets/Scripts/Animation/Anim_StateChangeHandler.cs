using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_StateChangeHandler : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gameStateKeeper.onGameStateChanged += HandleGameStateChanged;
    }

    private void OnDisable()
    {
        gameStateKeeper.onGameStateChanged -= HandleGameStateChanged;
    }

    private void HandleGameStateChanged(GameState currentGameState)
    {
        switch (currentGameState)
        {
            case GameState.LEVELSTART:
                PauseAnimation();
                break;

            case GameState.GAMEACTIVE:
                StartAnimation();
                break;

            case GameState.GAMEPAUSED:
                PauseAnimation();
                break;

            case GameState.LEVELEND:
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
