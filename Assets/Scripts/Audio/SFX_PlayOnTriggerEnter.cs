using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFX_PlayOnTriggerEnter : MonoBehaviour
{

    [EventRef] public string[] soundEvents;
    public bool soundEffectsOn = true;
    public bool triggerOn = true;
    public int eventIndex;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(otherTag))
        {
            if (soundEvents[eventIndex] != null && soundEffectsOn && triggerOn && !spawnBufferOn && gameManager.CurrentGameState == GameState.GAMEACTIVE)
            {
                PlaySoundEvent(eventIndex);

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