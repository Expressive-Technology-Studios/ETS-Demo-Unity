using UnityEngine;

public class ThaliaAnimationEvents : MonoBehaviour
{
    [SerializeField] GameObject _spear;
    [SerializeField] GameObject _thaliaHitPosition;
    [SerializeField] ParticleSystem _thaliaHitParticleEffect;
    [SerializeField] bool _effectsOn;

    public void DropWeapon()
    {
        _spear.SetActive(false);
    }

    public void ThaliaHit()
    {
        if (_effectsOn) Instantiate(_thaliaHitParticleEffect, _thaliaHitPosition.transform.position, Quaternion.identity);
    }
}
