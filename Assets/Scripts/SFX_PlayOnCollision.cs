using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFX_PlayOnCollision : MonoBehaviour
{

    [EventRef] public string[] soundEvents;
    public bool soundEffectsOn = true;
    public bool collisionOn = false;
    public int collisionEventIndex;

    // public float expirationTimerDefault;
    // public float expirationTimer;

    // public string otherTag;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void PlaySoundEvent(int i, float velocity)
    {
        if (soundEvents[i] != null && soundEffectsOn)
        {
            // RuntimeManager.PlayOneShot(soundEvents[i]);
            RuntimeManager.PlayOneShotAttached(soundEvents[i], this.gameObject);
        }
    }


    public void DisableSoundEffects()
    {
        soundEffectsOn = false;
    }

    private void OnCollisionEnter(Collision other)
    {

        // if (otherTag != string.Empty)
        // {
        //     if (other.gameObject.CompareTag(otherTag))
        //     {
        //         print("Collision between: " + this.gameObject.name + " & " + other.gameObject.name);
        //         PlaySoundEvent(collisionEventIndex, rb.velocity.magnitude);

        //         // expirationTimer = expirationTimerDefault;
        //         // collisionOn = true;
        //     }
        // }

        if (soundEvents[collisionEventIndex] != null && soundEffectsOn && collisionOn)
        {
            PlaySoundEvent(collisionEventIndex, rb.velocity.magnitude);

        }
    }

    private void Update()
    {

        // if (collisionOn)
        // {
        //     if (expirationTimer <= expirationTimerDefault && expirationTimer > 0)
        //     {
        //         expirationTimer -= Time.deltaTime;
        //     }
        //     else
        //     {
        //         collisionOn = false;
        //     }
        // }
    }
}