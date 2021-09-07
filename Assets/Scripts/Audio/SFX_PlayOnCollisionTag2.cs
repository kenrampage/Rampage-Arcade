using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFX_PlayOnCollisionTag2 : MonoBehaviour
{

    [EventRef] public string[] soundEvents;
    public bool soundEffectsOn = true;
    public bool collisionOn = true;
    public bool triggerOn = true;
    public int collisionEventIndex;

    private bool spawnBufferOn = true;
    public float spawnBufferDefault = .1f;
    private float spawnBufferCurrent;

    // private GameManager2 gameManager2;

    // public float expirationTimerDefault;
    // public float expirationTimer;

    public string otherTag;

    private Rigidbody rb;

    private void Awake()
    {
        // gameManager2 = GameManager2.Instance;
        spawnBufferOn = true;
        spawnBufferCurrent = spawnBufferDefault;
        rb = GetComponent<Rigidbody>();
    }


    public void PlaySoundEvent(int i)
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
        if (other.gameObject.CompareTag(otherTag))
        {
            if (soundEvents[collisionEventIndex] != null && soundEffectsOn && collisionOn  && !spawnBufferOn)
            {
                PlaySoundEvent(collisionEventIndex);

            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(otherTag))
        {
            if (soundEvents[collisionEventIndex] != null && soundEffectsOn && triggerOn  && !spawnBufferOn)
            {
                PlaySoundEvent(collisionEventIndex);

            }
        }
    }


    private void Update()
    {
        if (spawnBufferOn)
        {
            spawnBufferCurrent -= Time.deltaTime;
            if (spawnBufferCurrent <= 0)
            {
                spawnBufferOn = false;
            }
        }
    }

}