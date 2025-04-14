using System.Collections;
using UnityEngine;

[System.Serializable]
public struct Slide
{
    public GameObject media;
    public float duration;
}

public class SlideShow : MonoBehaviour
{
    public Slide[] slides;

    private void Start()
    {
        // For testing...
        PlaySlideShow();
    }

    public void PlaySlideShow()
    {
        StartCoroutine(PlaySlidesInSequence());
    }

    IEnumerator PlaySlidesInSequence()
    {
        foreach (var slide in slides)
        {
            slide.media.SetActive(true);
            yield return new WaitForSeconds(slide.duration);
        }

        EndSlideShow();
    }

    void EndSlideShow()
    {
        foreach (var slide in slides)
        {
            slide.media.SetActive(false);
        }
    }
}
