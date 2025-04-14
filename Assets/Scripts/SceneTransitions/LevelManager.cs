using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;

// Credit: https://www.youtube.com/watch?v=hF1mkGENOS4

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject _transitionsContainer;
    [SerializeField] Slider _progressBar;

    SceneTransition[] _transitions;

    // Singleton pattern
    static LevelManager _instance;
    public static LevelManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Level Manager is null.");
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _transitions = _transitionsContainer.GetComponentsInChildren<SceneTransition>();
    }

    public void LoadScene(string sceneName, string transitionName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, transitionName));
    }

    IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    {
        SceneTransition transition = _transitions.First(t => t.name == transitionName); 

        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        yield return transition.AnimateTransitionIn();

        _progressBar.gameObject.SetActive(true);

        do
        {
            _progressBar.value = scene.progress;
            yield return null;
        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        _progressBar.gameObject.SetActive(false);

        yield return transition.AnimateTransitionOut();

    }
}
