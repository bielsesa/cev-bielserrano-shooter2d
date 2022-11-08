using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 3;

    public Image healthBar;

    void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            health--;

            healthBar.fillAmount = (float) health / maxHealth;

            Destroy(collision.gameObject);
            
            CheckDeath();
            Debug.Log(health);
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
