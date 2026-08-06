using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            Debug.LogError("MusicToggle: No AudioSource on this GameObject!");
    }

    public void ToggleMusic()
    {
        if (audioSource == null) return;

        if (isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();

        isPlaying = !isPlaying;
        Debug.Log(isPlaying ? "🎵 Music ON" : "🔇 Music OFF");
    }
}