using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    void OnDestroy()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }
}
