using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFX_ChancePlayOnSpawn : MonoBehaviour
{

    [EventRef] public string[] soundEvents;
    public bool soundEffectsOn = true;

    public float chanceThreshhold;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float f = Random.Range(0f, 1f);
        if (f <= chanceThreshhold)
        {
            int i = Random.Range(0, soundEvents.Length);
            PlaySoundEvent(i);
        }

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


}