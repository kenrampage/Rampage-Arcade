using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCollision : MonoBehaviour
{
    private GameManager1 gameManager1;

    private SFX_PlayOneShot sfxPlayer;
    public int sfxIndex;

    // Start is called before the first frame update
    void Start()
    {
        
        gameManager1 = GameManager1.Instance;
        sfxPlayer = gameManager1.sfxPlayer;
    }


    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "Player")
        {
            sfxPlayer.PlaySoundEvent(sfxIndex);
            Object.Destroy(this.gameObject);
            gameManager1.IncreaseScore();
            gameManager1.ResetTimer();
            gameManager1.spawnManager1.RespawnLevelObjects();
            
        }
    }

}
