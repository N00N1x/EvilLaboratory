using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int EnemymaxHealth = 4;
    [SerializeField] public int EnemycurrentHealth;
    void Start()
    {
        EnemycurrentHealth = EnemymaxHealth;
    }
    private void Die()
    {
        Destroy(gameObject);
  


    }

    private void Heal(int amount)
    {
        EnemycurrentHealth += amount;
        if (EnemycurrentHealth > EnemymaxHealth)
        {
            EnemycurrentHealth = EnemymaxHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return EnemycurrentHealth;
    }


    public void TakeDamage(int Damage)
    {
        EnemycurrentHealth -= Damage;
        if (EnemycurrentHealth < 0)
            EnemycurrentHealth = 0;
        if (EnemycurrentHealth <= 0)
        {
            Die();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
