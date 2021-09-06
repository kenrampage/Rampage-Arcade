using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

    private GameManager gameManager;
    private ScoreKeeper scoreKeeper;
    private SFXPlayer2D sfxPlayer;

    [SerializeField] private string barrierTag;
    [SerializeField] private string enemyTag;

    private void Awake()
    {
        sfxPlayer = FindObjectOfType<SFXPlayer2D>();
        gameManager = FindObjectOfType<GameManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == barrierTag)
        {
            this.gameObject.SetActive(false);
        }

        if (other.transform.tag == enemyTag)
        {
            sfxPlayer.PlaySoundEvent(7);
            this.gameObject.SetActive(false);
            Destroy(other.gameObject);
            scoreKeeper.IncrementScore();
        }
    }

}