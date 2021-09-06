using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMouse : MonoBehaviour
{
    private Camera mainCamera;
    private GameManager gameManager;

    [SerializeField] private GameObject mouseCursor;
    [SerializeField] private string targetLayer;
    [SerializeField] private Vector3 offset;


    private void Awake()
    {
        mainCamera = Camera.main;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CurrentGameState == GameManager.GameState.GAMEACTIVE)
        {
            mouseCursor.SetActive(true);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask(targetLayer)))
            {
                mouseCursor.transform.position = new Vector3(raycastHit.point.x + offset.x, raycastHit.point.y + offset.y, raycastHit.point.z + offset.z);
            }
        }
        else
        {
            mouseCursor.SetActive(false);
        }
    }
}
