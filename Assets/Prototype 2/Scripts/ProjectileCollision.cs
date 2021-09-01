using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{

    private GameManager2 gameManager2;

    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.transform.tag == "Enemy")
    //     {
    //         this.gameObject.SetActive(false);
    //         Destroy(other.gameObject);
    //         GameManager2.Instance.IncreaseScore();
    //     }
    // }

    private void Start()
    {
        gameManager2 = GameManager2.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Barrier")
        {
            this.gameObject.SetActive(false);
        }

        if (other.transform.tag == "Enemy")
        {
            gameManager2.sfxPlayer.PlaySoundEvent(7);
            this.gameObject.SetActive(false);
            Destroy(other.gameObject);
            GameManager2.Instance.IncreaseScore();
        }
    }

}
