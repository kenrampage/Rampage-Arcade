using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15f;
    // private PlayerController3 playerControllerScript;
    public float leftBound = -15;

    private GameManager3 gameManager3;

    // Start is called before the first frame update
    void Start()
    {
        gameManager3 = GameManager3.Instance;
        // playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (gameManager3.gameIsActive)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }

    }

}
