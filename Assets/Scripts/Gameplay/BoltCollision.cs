using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoltCollision : MonoBehaviour
{
    [SerializeField] private SFX_PlayOneShot sfxPlayer;
    // public static event Action onBoltPickup;



    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (other.transform.tag == "Player")
    //     {
            
    //         onBoltPickup?.Invoke();
    //         Destroy(this.gameObject);
    //         // sfxPlayer.PlaySoundEvent(sfxIndex);
    //         // scoreKeeper.UpdateScore(pointValue);
    //         // timer.ResetTimer();
    //         // spawnManager1.RespawnLevelObjects();
            
            
    //     }
    // }

}
