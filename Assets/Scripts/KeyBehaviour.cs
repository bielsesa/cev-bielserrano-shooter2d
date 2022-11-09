using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    public AudioClip collectKeyAudio;
    public AudioClip openDoorAudio;

    private AudioSource _audioSource;

    private bool _hasKey;
    private GameObject _key;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Key")
        {
            other.transform.SetParent(transform);
            other.transform.position = transform.position - new Vector3(-0.6f, 0.06f, 0.6f);
            _hasKey = true;

            _audioSource.clip = collectKeyAudio;
            _audioSource.Play();

            _key = other.gameObject;
        }

        if (other.transform.tag == "Door" && _hasKey)
        {
            _audioSource.clip = openDoorAudio;
            _audioSource.Play();

            Destroy(other.gameObject);
            Destroy(_key);
        }
    }
}
