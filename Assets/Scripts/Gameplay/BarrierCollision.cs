using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierCollision : MonoBehaviour
{

    // public void OnCollisionEnter(Collision other)
    // {
    //     if(other.transform.tag == "Enemy")
    //     {
    //         Destroy(other.gameObject);
    //         GameManager2.Instance.EndGame();
    //         print("Game Over");
    //     }
    // }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            // this.gameObject.SetActive(false);
            // Destroy(other.gameObject);
            // GameManager2.Instance.IncreaseScore();

            print("Game Over");
        }
    }


}
