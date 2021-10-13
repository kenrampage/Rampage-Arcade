using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] startUI;
    [SerializeField] private GameObject[] pauseUI;
    [SerializeField] private GameObject[] gameUI;
    [SerializeField] private GameObject[] endUI;

    public void StartUIOn()
    {
        DisableObjects(pauseUI);
        DisableObjects(gameUI);
        DisableObjects(endUI);
        EnableObjects(startUI);
    }

    public void GameUIOn()
    {
        DisableObjects(pauseUI);
        DisableObjects(startUI);
        DisableObjects(endUI);
        EnableObjects(gameUI);
    }


    public void PauseUIOn()
    {
        DisableObjects(startUI);
        DisableObjects(gameUI);
        DisableObjects(endUI);
        EnableObjects(pauseUI);
    }

    public void EndUIOn()
    {
        DisableObjects(pauseUI);
        DisableObjects(gameUI);
        DisableObjects(startUI);
        EnableObjects(endUI);
    }

    private void EnableObjects(GameObject[] objects)
    {
        foreach (var item in objects)
        {
            item.SetActive(true);
        }
    }

    private void DisableObjects(GameObject[] objects)
    {
        foreach (var item in objects)
        {
            item.SetActive(false);
        }
    }

}
