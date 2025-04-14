using UnityEngine;

public class AlienAnimationEvents : MonoBehaviour
{
    [SerializeField] ParticleSystem _modelTransitionParticleEffect;

    public void PlayModelTransitionEffect()
    {
        _modelTransitionParticleEffect.Play();
    }

    public void DestroyAlien()
    {
        Destroy(gameObject);
    }
}
