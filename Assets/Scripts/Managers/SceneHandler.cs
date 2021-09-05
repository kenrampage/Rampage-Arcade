using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private float loadDelay;

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
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
