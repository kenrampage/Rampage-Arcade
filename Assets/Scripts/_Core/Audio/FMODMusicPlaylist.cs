using UnityEngine;
using FMODUnity;

public class FMODMusicPlaylist : MonoBehaviour
{
    [SerializeField] private SOGameStateKeeper gameStateKeeper;
    
    public bool shuffle;
    public int eventIndex;
    [EventRef] public string[] fmodEvents;

    FMOD.Studio.EventInstance eventInstance;

    public FMOD.Studio.PLAYBACK_STATE playbackState;
    public bool isPaused;

    public bool debugControls;

    public int section;

    public float fadeInTime;

    


    private void OnEnable()
    {
        gameStateKeeper.onGameStateChanged += HandleGameStateChanged;
    }

    private void OnDisable()
    {
        gameStateKeeper.onGameStateChanged -= HandleGameStateChanged;
    }


    private void Start()
    {
        if (shuffle)
        {
            eventIndex = Random.Range(0, fmodEvents.Length - 1);
        }

        eventInstance = FMODUnity.RuntimeManager.CreateInstance(fmodEvents[eventIndex]);
        eventInstance.start();
    }

    private void Update()
    {
        CheckPlaybackState();
        eventInstance.setParameterByName("Section", section);

        if (debugControls)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {

                if (playbackState == FMOD.Studio.PLAYBACK_STATE.STOPPED)
                {
                    PlayMusic();
                }
                else if (playbackState == FMOD.Studio.PLAYBACK_STATE.PLAYING)
                {
                    if (!isPaused)
                    {
                        PauseMusic();
                    }
                    else
                    {
                        UnpauseMusic();
                    }
                }

            }

        }


    }

    public void PlayMusic()
    {

        eventInstance.start();
    }

    public void StopMusic()
    {
        eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

    }

    public void PauseMusic()
    {

        if (!isPaused)
        {
            eventInstance.setPaused(true);
        }

    }

    public void UnpauseMusic()
    {
        if (isPaused)
        {
            eventInstance.setPaused(false);
        }
    }

    public void CheckPlaybackState()
    {
        eventInstance.getPlaybackState(out playbackState);
        eventInstance.getPaused(out isPaused);

    }

    private void OnDestroy()
    {
        StopMusic();
    }

    public void SetSection(int i)
    {
        section = i;
    }

    public void HighPassOn()
    {
        eventInstance.setParameterByName("HighPass", 1);

    }

    public void HighPassOff()
    {
        eventInstance.setParameterByName("HighPass", 0);
    }

    private void HandleGameStateChanged(GameState currentGameState)
    {
        switch (currentGameState)
        {
            case GameState.LEVELSTART:
                HighPassOff();
                break;

            case GameState.GAMEACTIVE:
                HighPassOff();
                break;

            case GameState.GAMEPAUSED:
                HighPassOn();
                break;

            case GameState.LEVELEND:
                HighPassOn();
                break;

            default:
                break;
        }
    }
}
