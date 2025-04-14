using System.Collections;
using UnityEngine;

public class MinotaurAnimationEvents : MonoBehaviour
{
    [SerializeField] Animator _minotaurBlockerAnimator;
    [SerializeField] ParticleSystem _minotaurHitParticleEffect;
    [SerializeField] Transform _minotaurHitPosition;
    [SerializeField] bool _effectsOn;

    public void FadeMinotaur()
    {
        //StartCoroutine(LowerMinotaur());
        if (_effectsOn) _minotaurBlockerAnimator.SetTrigger("FadeOut");
    }

    IEnumerator LowerMinotaur()
    {
        float stepSize = 0.1f;
        while (transform.position.y > -5)
        {
            transform.Translate(Vector3.down * stepSize * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void MinotaurHit()
    {
        if (_effectsOn) Instantiate(_minotaurHitParticleEffect, _minotaurHitPosition.position, Quaternion.identity);
    }
}
