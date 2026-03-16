using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [Header("Configuration")]
    public AudioClip clip;       
    public float volume = 1f;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlaySound()
    {
        if (clip != null)
            audioSource.PlayOneShot(clip, volume);
    }
}