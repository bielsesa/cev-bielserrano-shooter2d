using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bouncingVelocity = 13f;

    private GameObject _audioManager;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Bouncer")
        {
            if (_audioManager != null) _audioManager.SendMessage("PlayBounceSound");
            _rigidbody.velocity = Vector3.up * bouncingVelocity;
        }
    }
}
