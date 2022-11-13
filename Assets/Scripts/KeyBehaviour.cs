using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KeyBehaviour : MonoBehaviour
{
    public AudioClip collectKeyAudio;
    public AudioClip openDoorAudio;

    public List<string> keyTypes;

    private AudioSource _audioSource;

    private bool _hasKey;
    public List<GameObject> _keys;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _keys = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Key")
        {
            other.transform.SetParent(transform);
            other.transform.position = transform.position - new Vector3(-0.6f, 0.06f, 0.6f);
            if (_keys.Count == 0) _hasKey = true;

            _audioSource.clip = collectKeyAudio;
            _audioSource.Play();

            _keys.Add(other.gameObject);
        }

        if (other.transform.tag == "Door" && _hasKey)
        {
            string doorType = other.gameObject.name.Replace("Door", string.Empty);
            
            // search for the corresponding key for the door
            GameObject key = _keys.FirstOrDefault(x => x.gameObject.name.StartsWith(doorType));
            if (key != null)
            {
                _audioSource.clip = openDoorAudio;
                _audioSource.Play();

                Destroy(other.gameObject);

                _keys.Remove(key);
                Destroy(key);

                if (_keys.Count == 0) _hasKey = false;
            }
        }
    }
}
