using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SFX_BallRolling : MonoBehaviour
{

    [EventRef] public string soundEvent;
    FMOD.Studio.EventInstance eventInstance;
    public FMOD.Studio.PLAYBACK_STATE playbackState;
    public bool isPlaying;

    public FMODUnity.StudioEventEmitter emitter;

    private Rigidbody rb;
    public float currentSpeed;

    private GameManager4 gameManager4;

    // Start is called before the first frame update
    void Start()
    {
        gameManager4 = GameManager4.Instance;
        rb = GetComponent<Rigidbody>();

        emitter.Event = soundEvent;
        // eventInstance = FMODUnity.RuntimeManager.CreateInstance(soundEvent);

    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = rb.velocity.magnitude;
        if (gameManager4.gameIsActive)
        {
            emitter.SetParameter("Ball Speed", currentSpeed);
        }
        else
        {
            emitter.SetParameter("Ball Speed", 0);
        }

    }

    public void StartSound()
    {
        emitter.Play();

    }

    public void StopSound()
    {
        emitter.Stop();
    }

    private void OnCollisionStay(Collision other)
    {
        CheckPlaybackState();
        if (!isPlaying && other.gameObject.CompareTag("Ground"))
        {
            StartSound();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        CheckPlaybackState();
        if (isPlaying && other.gameObject.CompareTag("Ground"))
        {
            StopSound();
        }
    }

    public void CheckPlaybackState()
    {
        isPlaying = emitter.IsPlaying();
        eventInstance.getPlaybackState(out playbackState);

    }
}
