using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashFadeLoader : MonoBehaviour
{
    public CanvasGroup canvasGroup;       // assign the Canvas' CanvasGroup
    public string sceneToLoad = "ARScene";
    public float fadeInTime = 0.5f;
    public float holdTime = 3.0f;
    public float fadeOutTime = 0.5f;

    void Start()
    {
        if (canvasGroup == null) Debug.LogError("CanvasGroup not assigned.");
        StartCoroutine(PlayAndLoad());
    }

    private IEnumerator PlayAndLoad()
    {
        // start invisible
        canvasGroup.alpha = 0f;

        // fade in
        float t = 0f;
        while (t < fadeInTime)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(t / fadeInTime);
            yield return null;
        }
        canvasGroup.alpha = 1f;

        // hold
        yield return new WaitForSeconds(holdTime);

        // fade out
        t = 0f;
        while (t < fadeOutTime)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = 1f - Mathf.Clamp01(t / fadeOutTime);
            yield return null;
        }
        canvasGroup.alpha = 0f;

        // load next scene
        SceneManager.LoadScene(sceneToLoad);
    }
}