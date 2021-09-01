using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Enemy : MonoBehaviour
{
    [EventRef] public string soundEvent_Death;
    private Rigidbody enemyRb;
    private GameObject player;
    public float speed;
    private Vector3 lookDirection;
    public float fadeTime;
    public float deathHeight;
    private bool isDefeated;


    private GameManager4 gameManager4;

    // Start is called before the first frame update
    void Start()
    {
        isDefeated = false;
        gameManager4 = GameManager4.Instance;
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {

        lookDirection = (player.transform.position - transform.position).normalized;


        if (transform.position.y < deathHeight && !isDefeated)
        {
            isDefeated = true;
            gameManager4.IncreaseScore();
            LeanTween.alpha(this.gameObject, 0, fadeTime);
            FMODUnity.RuntimeManager.PlayOneShotAttached(soundEvent_Death, this.gameObject);
        }

        if (transform.position.y < -10)
        {

            Destroy(gameObject);

        }


    }


    private void FixedUpdate()
    {
        if (gameManager4.gameIsActive && !isDefeated)
        {
            enemyRb.AddForce(lookDirection * speed);

        }
    }
}
