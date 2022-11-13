using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private GameObject _audioManager;

    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            if (_audioManager != null) _audioManager.SendMessage("PlayEnemyDeathSound");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
