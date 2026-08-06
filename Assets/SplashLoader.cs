using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLoader : MonoBehaviour
{
    [Tooltip("Scene name to load after splash")]
    public string sceneToLoad = "HomeMenu"; // replace with your AR scene name
    [Tooltip("Seconds to wait before loading")]
    public float delaySeconds = 4f;

    void Start()
    {
        Invoke(nameof(LoadNext), delaySeconds);
    }

    void LoadNext()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}