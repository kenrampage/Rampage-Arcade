using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinThisObject : MonoBehaviour
{
    private GameManager2 gameManager2;
    private Vector3 rotationDirection;
    public float rotationSpeedMin;
    public float rotationSpeedMax;
    private float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gameManager2 = GameManager2.Instance;
        rotationDirection = new Vector3(Random.Range(-1,1),Random.Range(-1,1),Random.Range(-1,1));
        rotationSpeed = Random.Range(rotationSpeedMin,rotationSpeedMax);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameManager2.gameIsActive)
        {
            transform.Rotate( rotationDirection * rotationSpeed, Space.Self);
        }
        
    }
}
