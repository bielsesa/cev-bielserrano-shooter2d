using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 3;

    public Image healthBar;

    public AudioClip damageAppliedSound;
    public AudioClip fallSound;

    private AudioSource _audioSource;

    void Start()
    {
        health = maxHealth;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            health--;

            healthBar.fillAmount = (float) health / maxHealth;
            
            _audioSource.clip = damageAppliedSound;
            _audioSource.Play();

            Destroy(collision.gameObject);            
            CheckDeath();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "FallLimit")
        {
            health = 0;

            _audioSource.clip = fallSound;
            _audioSource.Play(); // no llega a sonar porque no le da tiempo
            
            CheckDeath();
        }

    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            transform.Find("Main Camera").gameObject.transform.SetParent(null);
            Destroy(gameObject);
            SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Single);
        }
    }
}
