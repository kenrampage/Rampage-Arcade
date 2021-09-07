using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager5 : Singleton<GameManager5>
{

    // public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI gameOverText;
    // public Button restartButton;
    // public GameObject titleScreen;
    // private int score;

    // public bool isGameActive;

    public int currentScore;
    public bool gameIsActive;

    public GameObject startUI;
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject endUI;

    public SpawnManager5 spawnManager5;

    public int difficulty;

    public float delayTime;

    // public SFXPlayer2D sfxPlayer;
    public int sfxIndexPause;
    public int sfxIndexUnPause;

    // public MusicManager musicManager;


    private void Start()
    {
        Time.timeScale = 1f;
        InitializeLevel();
        ResetGravity();

    }


    // Update is called once per frame
    void Update()
    {

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
        spawnManager5.StartSpawning(difficulty);

    }

    public void PauseGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        gameIsActive = false;
        Time.timeScale = 0f;
        // sfxPlayer.PlaySoundEvent(sfxIndexPause);
        // musicManager.HighPassOn();
    }

    public void UnpauseGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        endUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsActive = true;
        // sfxPlayer.PlaySoundEvent(sfxIndexUnPause);
        // musicManager.HighPassOff();
    }

    public void EndGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(true);
        gameIsActive = false;
        Time.timeScale = 0f;
        // musicManager.HighPassOn();
        // sfxPlayer.PlaySoundEvent(3);
    }

    public void InitializeLevel()
    {

        currentScore = 0;
        gameIsActive = false;
        startUI.SetActive(true);
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);
    }

    // public void LoadMainMenu()
    // {
    //     SceneManager.LoadScene("MainMenu");
    // }

    // public void ReloadScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

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

    public void ResetGravity()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

    }

    public void SetDifficulty(int d)
    {
        difficulty = d;
    }
}
