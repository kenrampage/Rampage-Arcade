using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : Singleton<GameManager2>
{

    public int currentScore;
    public bool gameIsActive;

    public GameObject startUI;
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject endUI;

    public SpawnManager2 spawnManager2;
    public GameObject player;

    public int currentAmmo;
    public int maxAmmo;

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
        ResetAmmo();
        InitializeLevel();
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

    }

    public void PauseGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        gameIsActive = false;
        Time.timeScale = 0f;
        sfxPlayer.PlaySoundEvent(sfxIndexPause);
        musicManager.HighPassOn();
    }

    public void UnpauseGame()
    {
        startUI.SetActive(false);
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        endUI.SetActive(false);
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
        Time.timeScale = 0f;
        musicManager.HighPassOn();
        sfxPlayer.PlaySoundEvent(3);
    }


    public void IncreaseScore()
    {
        currentScore++;
    }

    public void InitializeLevel()
    {

        currentScore = 0;
        gameIsActive = false;
        startUI.SetActive(true);
        pauseUI.SetActive(false);
        gameUI.SetActive(false);
        endUI.SetActive(false);
        musicManager.HighPassOff();
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

    public void DecreaseAmmo()
    {
        currentAmmo--;
    }

    public void ResetAmmo()
    {
        currentAmmo = maxAmmo;
    }


}
