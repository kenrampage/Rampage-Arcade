using UnityEngine;
using FMODUnity;

public class SoundPlayer2D : MonoBehaviour
{
    [EventRef] public string[] soundEvents;
    [SerializeField] private bool soundEffectsOn = true;

    public void PlaySoundEvent(int i)
    {
        if (soundEvents[i] != null && soundEffectsOn)
        {
            RuntimeManager.PlayOneShot(soundEvents[i]);
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
