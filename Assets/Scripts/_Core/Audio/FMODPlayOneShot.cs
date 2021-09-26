using UnityEngine;
using FMODUnity;

public class FMODPlayOneShot : MonoBehaviour
{
    [EventRef] public string fmodEvent;
    [SerializeField] private bool soundEffectsOn = true;

    public void PlaySoundEvent()
    {
        if (fmodEvent != null && soundEffectsOn)
        {
            RuntimeManager.PlayOneShot(fmodEvent);
        }


    }

    public void PlaySoundEventAttached()
    {
        if (fmodEvent != null && soundEffectsOn)
        {
            RuntimeManager.PlayOneShotAttached(fmodEvent, gameObject);
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
