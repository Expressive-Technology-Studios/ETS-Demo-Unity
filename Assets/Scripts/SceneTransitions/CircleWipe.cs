using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CircleWipe : SceneTransition
{
    [SerializeField] Image _circle;

    public override IEnumerator AnimateTransitionIn()
    {
        _circle.rectTransform.anchoredPosition = new Vector2(-2200f, 0f);
        var tweener = _circle.rectTransform.DOAnchorPosX(0f, 1f);
        yield return tweener.WaitForCompletion();
    }

    public override IEnumerator AnimateTransitionOut()
    {
        var tweener = _circle.rectTransform.DOAnchorPosX(2200f, 1f);
        yield return tweener.WaitForCompletion();
    }
}
