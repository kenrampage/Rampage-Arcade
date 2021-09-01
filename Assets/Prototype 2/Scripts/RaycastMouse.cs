using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMouse : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public int layerMask = 3;
    private GameManager2 gameManager2;
    private MeshRenderer meshRenderer;


    private void Start()
    {
        gameManager2 = GameManager2.Instance;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager2.gameIsActive)
        {
            meshRenderer.enabled = true;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity, LayerMask.GetMask("Ground")))
            {
                transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z);
            }
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
