using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Game Manager is null.");
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
        // Play some background music
    }

    void Update()
    {
        if( Keyboard.current.aKey.wasPressedThisFrame)
        {
            LevelManager.Instance.LoadScene("Level1", "CrossFade");
            // Play some different music?
        }

        if( Keyboard.current.rKey.wasPressedThisFrame)
        {
            LevelManager.Instance.LoadScene("Main", "CircleWipe");
        }
    }
}
