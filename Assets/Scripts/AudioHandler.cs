using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public AudioClip levelMusic;
    public AudioClip enemyDestroyAudio;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (levelMusic != null)
        {
            _audioSource.loop = true;
            _audioSource.clip = levelMusic;
            _audioSource.Play();
        }
    }

    public void PlayEnemyDeathSound()
    {
        _audioSource.PlayOneShot(enemyDestroyAudio, 1.2f);
    }
}
