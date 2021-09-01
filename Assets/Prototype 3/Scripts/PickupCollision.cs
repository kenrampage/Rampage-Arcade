using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCollision : MonoBehaviour
{
    private GameManager3 gameManager3;

    // Start is called before the first frame update
    void Start()
    {
        gameManager3 = GameManager3.Instance;
    }


    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Player")
        {
            Object.Destroy(this.gameObject);
            gameManager3.IncreaseScore();
            gameManager3.sfxPlayer.PlaySoundEvent(5);
        }
    }

}
