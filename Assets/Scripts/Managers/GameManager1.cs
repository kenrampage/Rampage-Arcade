using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : GameManager
{

    // public int currentScore;
    // public float roundTime;
    // public float currentTime;
    // public bool gameIsActive;

    // public GameObject startUI;
    // public GameObject pauseUI;
    // public GameObject gameUI;
    // public GameObject endUI;

    public SpawnManager1 spawnManager1;

    // public GameObject player;

    // public bool timerOn;
    // public float delayTime;

    // public SFX_PlayOneShot sfxPlayer;
    // public int sfxIndexPause;
    // public int sfxIndexUnPause;

    // public MusicManager musicManager;
    // public UIManager uiManager;

    // public enum GameState
    // {
    //     LEVELSTART,
    //     GAMEACTIVE,
    //     GAMEPAUSED,
    //     LEVELEND,
    // }

    // public GameState currentGameState;
    // public GameState previousGameState;


    // override public void Awake()
    // {
    //     base.Awake();

    // }

    private void Start()
    {
        InitializeLevel();
    }



    // // Update is called once per frame
    // void Update()
    // {

    //     if (Input.GetKeyDown(KeyCode.Escape)
    //     {
    //         PauseGame();
    //     }
    //     else if (Input.GetKeyDown(KeyCode.Escape)
    //     {
    //         UnpauseGame();
    //     }
    // }

    // public void StartGame()
    // {

    //     Time.timeScale = 1f;
    //     // gameIsActive = true;

    // }

    // public void PauseGame()
    // {
    //     // gameIsActive = false;
    //     Time.timeScale = 0f;
    //     // timerOn = false;
    //     // sfxPlayer.PlaySoundEvent(sfxIndexPause);
    //     // musicManager.HighPassOn();
    // }

    // public void UnpauseGame()
    // {

    //     // timerOn = true;
    //     Time.timeScale = 1f;
    //     // gameIsActive = true;
    //     // sfxPlayer.PlaySoundEvent(sfxIndexUnPause);
    //     // musicManager.HighPassOff();
    // }

    public void EndGame()
    {

        // gameIsActive = false;
        // timerOn = false;
        // sfxPlayer.PlaySoundEvent(4);
        // musicManager.HighPassOn();
    }

    // public void TimerCountdown()
    // {
    //     if (gameIsActive && timerOn)
    //     {
    //         currentTime = currentTime - Time.deltaTime;
    //     }

    // }

    // public void IncreaseScore()
    // {
    //     currentScore++;
    // }

    // public void ResetTimer()
    // {
    //     currentTime = roundTime;
    // }

    // public void InitializeLevel()
    // {

    //     // currentScore = 0;
    //     // ResetTimer();
    //     gameIsActive = false;

    //     // musicManager.HighPassOff();
    // }

    // public void LoadMainMenu()
    // {
    //     Time.timeScale = 1f;
    //     StartCoroutine("LoadLevelDelay", "MainMenu");
    // }

    // public void ReloadScene()
    // {
    //     Time.timeScale = 1f;
    //     StartCoroutine("LoadLevelDelay", SceneManager.GetActiveScene().name);
    // }


    // public IEnumerator LoadLevelDelay(string sceneName)
    // {
    //     yield return new WaitForSeconds(delayTime);
    //     SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    // }


}
