using UnityEngine;

public class PlayParticlesOnEnable : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem;

    void OnEnable()
    {
        particleSystem.Play();
    }
}
