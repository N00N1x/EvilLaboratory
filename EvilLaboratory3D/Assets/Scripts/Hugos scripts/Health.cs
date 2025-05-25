using UnityEngine;
using UnityEngine.SceneManagement;  

public class Health : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth;
    public GameObject gameOverUI;

    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Die()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }


    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        if (currentHealth < 0)
            currentHealth = 0;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
  
}
