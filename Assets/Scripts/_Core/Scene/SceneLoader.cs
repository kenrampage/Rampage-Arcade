using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float loadDelay;

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine("LoadSceneWithDelay", "MainMenu");
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        StartCoroutine("LoadSceneWithDelay", SceneManager.GetActiveScene().name);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine("LoadSceneWithDelay", sceneName);
    }

    public IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
