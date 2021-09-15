using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundPlayer3D : MonoBehaviour
{

    [EventRef] public string[] soundEvents;
    [SerializeField] private bool soundEffectsOn = true;

    public void PlaySoundEvent(int i)
    {
        if (soundEvents[i] != null && soundEffectsOn)
        {
            RuntimeManager.PlayOneShotAttached(soundEvents[i], gameObject);
        }
    }

    public void DisableSoundEffects()
    {
        soundEffectsOn = false;
    }

    public void EnableSoundEffects()
    {
        soundEffectsOn = true;
    }

}
