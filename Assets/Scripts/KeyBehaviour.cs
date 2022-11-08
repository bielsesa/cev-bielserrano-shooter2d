using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    private bool _hasKey;
    private GameObject _key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Key")
        {
            other.transform.SetParent(transform);
            other.transform.position = transform.position - new Vector3(-0.6f, 0.06f, 0.6f);
            _hasKey = true;
            _key = other.gameObject;
        }

        if (other.transform.tag == "Door" && _hasKey)
        {
            Destroy(other.gameObject);
            Destroy(_key);
        }
    }
}
