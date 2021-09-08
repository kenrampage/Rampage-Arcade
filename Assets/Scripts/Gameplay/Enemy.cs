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


    private GameManager gameManager;
    private ScoreKeeper scoreKeeper;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }



    // Start is called before the first frame update
    void Start()
    {
        isDefeated = false;
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
            scoreKeeper.IncrementScore();
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
        if (gameManager.CurrentGameState == GameState.GAMEACTIVE && !isDefeated)
        {
            enemyRb.AddForce(lookDirection * speed);

        }
    }
}
