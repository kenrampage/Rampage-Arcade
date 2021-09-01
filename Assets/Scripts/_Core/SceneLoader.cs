using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName;
    public float delayTime;

    public void LoadLevel()
    {
        StartCoroutine("LoadLevelDelay");
    }

    public IEnumerator LoadLevelDelay()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
    }


}
