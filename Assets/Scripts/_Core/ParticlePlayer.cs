using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{

    [SerializeField] private ParticleSystem[] particleSystems;


    public void PlayParticle(int index)
    {
        particleSystems[index].Play();
    }

    public void StopParticle(int index)
    {
        particleSystems[index].Stop();
    }

    public void PauseParticle(int index)
    {
        particleSystems[index].Pause();
    }
}
