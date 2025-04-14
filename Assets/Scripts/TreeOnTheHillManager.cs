using System.Collections;
using UnityEngine;

public class TreeOnTheHillManager : MonoBehaviour
{
    [SerializeField] GameObject _thalia;
    [SerializeField] Animator _thaliaBlockerAnimator;
    [SerializeField] GameObject _minotaur;
    [SerializeField] GameObject _minotaurVisuals;
    [SerializeField] Animator _minotaurBlockerAnimator;
    [SerializeField] bool _effectsOn;

    Animator _minotaurAnimator;
    Animator _thaliaAnimator;

    private void Awake()
    {
        _thaliaAnimator = _thalia.GetComponent<Animator>();
        _minotaurAnimator = _minotaur.GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine("MinotaurTimeline");
        StartCoroutine("ThaliaTimeline");
    }

    IEnumerator MinotaurTimeline()
    {
        yield return new WaitForSeconds(18);
        _minotaurBlockerAnimator.SetTrigger("FadeIn");
        _minotaurVisuals.SetActive(true);
        _minotaurAnimator.SetTrigger("Start");
    }

    IEnumerator ThaliaTimeline()
    {
        // Timestamp: 47 - Starts
        yield return new WaitForSeconds(3);
        // Timestamp: 50 - Thalia appears (toughgirl)
        _thaliaBlockerAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(5f);
        // Timestamp: 55 - Thalia faded completely out
        if (_effectsOn) _thaliaBlockerAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3);
        // Timestamp: 58 FadeIn, walking
        _thaliaAnimator.SetTrigger("Walking");
        if (_effectsOn) _thaliaBlockerAnimator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(28);
        // Timestamp: 1:26 FadeIn, Thalia striking
        _thaliaAnimator.SetTrigger("Strike");
        yield return new WaitForSeconds(1.5f);
        // Timestamp: 1:27.5 FadeIn, Thalia reaction
        _thaliaAnimator.SetTrigger("Reaction");
        yield return new WaitForSeconds(18f);
        // Timestamp: 1:27.5 FadeIn, Thalia final fadeout
        if (_effectsOn) _thaliaBlockerAnimator.SetTrigger("FadeOut");
    }
}
