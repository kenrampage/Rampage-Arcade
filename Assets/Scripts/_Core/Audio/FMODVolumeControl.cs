using UnityEngine;
using FMODUnity;

public class FMODVolumeControl : MonoBehaviour
{
    [SerializeField] private SOFloat musicVolumeSO;
    [SerializeField] private SOFloat effectsVolumeSO;

    public FMOD.Studio.Bus musicBus;
    public FMOD.Studio.Bus effectsBus;

    private void Awake()
    {
        effectsBus = RuntimeManager.GetBus("bus:/SFX");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        SyncSOValues();
    }

    private void OnEnable()
    {
        musicVolumeSO.onValueChanged += SetMusicVolume;
        effectsVolumeSO.onValueChanged += SetEffectsVolume;
    }

    private void OnDisable()
    {
        musicVolumeSO.onValueChanged -= SetMusicVolume;
        effectsVolumeSO.onValueChanged -= SetEffectsVolume;
    }

    public void SetMusicVolume(float v)
    {
        musicBus.setVolume(v);
    }

    public void SetEffectsVolume(float v)
    {
        effectsBus.setVolume(v);
    }

    public float GetMusicVolume()
    {
        float v;
        musicBus.getVolume(out v);
        return v;
    }

    public float GetEffectsVolume()
    {
        float v;
        effectsBus.getVolume(out v);
        return v;
    }

    public void SyncSOValues()
    {
        musicVolumeSO.SetValue(GetMusicVolume());
        effectsVolumeSO.SetValue(GetEffectsVolume());
    }



}
