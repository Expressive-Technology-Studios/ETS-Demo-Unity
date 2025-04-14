using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// Reference: https://www.youtube.com/watch?v=_jtj73lu2Ko&t=26s

public class FadeMenuEvents : MonoBehaviour
{
    public List<Fade> fadeList;

    UIDocument _uIDocument;
    Button _fadeOutButton;
    Button _fadeInButton;

    private void Awake()
    {
        _uIDocument = GetComponent<UIDocument>();
        _fadeOutButton = _uIDocument.rootVisualElement.Q("FadeOutButton") as Button;
        _fadeOutButton.RegisterCallback<ClickEvent>(OnFadeOutClick);
        _fadeInButton = _uIDocument.rootVisualElement.Q("FadeInButton") as Button;
        _fadeInButton.RegisterCallback<ClickEvent>(OnFadeInClick);
        // YouTube video shows how to find all buttons in a visualElement and assign callbacks
    }

    private void OnDisable()
    {
        _fadeOutButton.UnregisterCallback<ClickEvent>(OnFadeOutClick);
    }

    void OnFadeOutClick(ClickEvent evt)
    {
        foreach (var fade in fadeList)
        {
            fade.StartFadeOut();
        }
    }

    void OnFadeInClick(ClickEvent evt)
    {
        foreach (var fade in fadeList)
        {
            fade.StartFadeIn();
        }
    }
}
