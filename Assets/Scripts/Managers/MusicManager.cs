using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip _menuMusic;

    [SerializeField]
    private AudioClip _gameMusic;

    private AudioSource _as;

    private Scene _currentScene;

    private void Awake()
    {
        _as = GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Start()
    {
        print("music manager started");
        _as.PlayOneShot(_menuMusic);
    }

    private void FixedUpdate()
    {
        // _currentScene = SceneManager.GetActiveScene();
        if (_currentScene != SceneManager.GetActiveScene())
        {
            _currentScene = SceneManager.GetActiveScene();
            print($"Current active scene is {_currentScene.name}");
            if (_currentScene.name == "Level1")
            {
                _as.Stop();
                _as.PlayOneShot(_gameMusic);
            }
        }
    }
}
