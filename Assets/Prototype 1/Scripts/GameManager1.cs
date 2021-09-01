using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : Singleton<GameManager1>
{

    public int currentScore;
    public float roundTime;
    public float currentTime;
    public bool gameIsActive;

    public GameObject startUI;
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject endUI;

    public SpawnManager1 spawnManager1;
    
    public GameObject player;

    public bool timerOn;
    public float delayTime;

    public SFX_PlayOneShot sfxPlayer;
    public int sfxIndexPause;
    public int sfxIndexUnPause;

    public MusicManager musicManager;


    // override public void Awake()
    // {
    //     base.Awake();

    // }

    private void Start()
    {
        InitializeLevel();
    }



    // Update is called once per frame
    void Update()
    {
        TimerCountdown();

        if (currentTime <= 0)
        {
            currentTime = roundTime;
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && gameUI.gameObject.activeSelf)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseUI.gameObject.activeSelf)
        {
            UnpauseGame();
        }
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        endUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsActive = true;

    }

    public void PauseGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        gameIsActive = false;
        Time.timeScale = 0f;
        timerOn = false;
        sfxPlayer.PlaySoundEvent(sfxIndexPause);
        musicManager.HighPassOn();
    }

    public void UnpauseGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        endUI.SetActive(false);
        timerOn = true;
        Time.timeScale = 1f;
        gameIsActive = true;
        sfxPlayer.PlaySoundEvent(sfxIndexUnPause);
        musicManager.HighPassOff();
    }

    public void EndGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(true);
        gameIsActive = false;
        timerOn = false;
        sfxPlayer.PlaySoundEvent(4);
        musicManager.HighPassOn();
    }

    public void TimerCountdown()
    {
        if (gameIsActive && timerOn)
        {
            currentTime = currentTime - Time.deltaTime;
        }

    }

    public void IncreaseScore()
    {
        currentScore++;
    }

    public void ResetTimer()
    {
        currentTime = roundTime;
    }

    public void InitializeLevel()
    {

        currentScore = 0;
        ResetTimer();
        gameIsActive = false;
        startUI.SetActive(true);
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        musicManager.HighPassOff();
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine("LoadLevelDelay", "MainMenu");
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        StartCoroutine("LoadLevelDelay", SceneManager.GetActiveScene().name);
    }


    public IEnumerator LoadLevelDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }


}
