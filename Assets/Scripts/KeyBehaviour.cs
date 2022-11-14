using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class KeyBehaviour : MonoBehaviour
{
    [Header("Audios")]
    public AudioClip collectKeyAudio;
    public AudioClip openDoorAudio;

    [Header("Level")]
    public string levelToLoad;
    public float levelLoadingDelay = 3f;
    public string doorColorThatLoadsNextLevel;

    [Header("Keys")]
    public List<string> keyTypes;
    public List<GameObject> keys;

    private AudioSource _audioSource;

    private bool _hasKey;

    private GameObject _levelManager;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        keys = new List<GameObject>();
        _levelManager = GameObject.FindGameObjectWithTag("LevelManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Key")
        {
            other.transform.SetParent(transform);
            other.transform.position = transform.position - new Vector3(-0.6f, 0.06f, 0.6f);
            if (keys.Count == 0) _hasKey = true;

            _audioSource.clip = collectKeyAudio;
            _audioSource.Play();

            keys.Add(other.gameObject);
        }

        if (other.transform.tag == "Door" && _hasKey)
        {
            string doorType = other.gameObject.name.Replace("Door", string.Empty);
            
            // search for the corresponding key for the door
            GameObject key = keys.FirstOrDefault(x => x.gameObject.name.StartsWith(doorType));
            if (key != null)
            {
                _audioSource.clip = openDoorAudio;
                _audioSource.Play();

                Destroy(other.gameObject);

                keys.Remove(key);
                Destroy(key);

                if (keys.Count == 0)
                {
                    _hasKey = false;                    
                }

                Debug.Log($"key starts with {key.gameObject.name.StartsWith(doorColorThatLoadsNextLevel)}");

                if (key.gameObject.name.StartsWith(doorColorThatLoadsNextLevel))
                {
                    Debug.Log("load next level");

                    Debug.Log($"is level manager null? {_levelManager == null}");

                    // load next scene with a little bit of delay
                    if (_levelManager != null) _levelManager.GetComponent<LevelHandler>().LoadSceneWithDelay(levelToLoad, levelLoadingDelay);
                }
            }
        }
    }
}
