using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFX_PlayOnCollisionTag1 : MonoBehaviour
{

    [EventRef] public string[] soundEvents;
    public bool soundEffectsOn = true;
    public bool collisionOn = true;
    public int collisionEventIndex;

    private bool spawnBufferOn = true;
    public float spawnBufferDefault = .1f;
    private float spawnBufferCurrent;

    private GameManager gameManager;

    // public float expirationTimerDefault;
    // public float expirationTimer;

    public string otherTag;

    private Rigidbody rb;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
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
            if (soundEvents[collisionEventIndex] != null && soundEffectsOn && collisionOn && gameManager.CurrentGameState == GameState.GAMEACTIVE && !spawnBufferOn)
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