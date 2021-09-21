using UnityEngine;
using FMODUnity;

public class FMODPlayOneShot : MonoBehaviour
{
    [EventRef] public string[] fmodEvents;
    [SerializeField] private bool soundEffectsOn = true;

    public void PlaySoundEvent(int i)
    {
        if (fmodEvents[i] != null && soundEffectsOn)
        {
            RuntimeManager.PlayOneShot(fmodEvents[i]);
        }
    }

    public void PlaySoundEventAttached(int i)
    {
        if (fmodEvents[i] != null && soundEffectsOn)
        {
            RuntimeManager.PlayOneShotAttached(fmodEvents[i], gameObject);
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
