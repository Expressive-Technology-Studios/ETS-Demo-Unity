using UnityEngine;
using UnityEngine.SceneManagement;

//Changes scene as soon as the script is enabled. Start this disabled and enable it from the timeline using an Activation Track.
public class SimpleSceneChange : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    public void OnEnable()
    {
        SceneManager.LoadScene(sceneName);
    }
}
