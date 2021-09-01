using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFX_StepSound : MonoBehaviour
{
    [EventRef] public string soundEvent;
    public bool soundEffectsOn = true;

    public void PlaySoundEvent()
    {
        if (soundEvent != null && soundEffectsOn)
        {
            RuntimeManager.PlayOneShot(soundEvent);
        }
    }


    public void DisableSoundEffects()
    {
        soundEffectsOn = false;
    }


    public void Step()
    {
        PlaySoundEvent();
    }
}
