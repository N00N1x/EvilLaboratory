using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] public int damageAmount = 25;
    [SerializeField] public float damageInterval = 1f;
    [SerializeField] private float damageTimer = 0f;
    [SerializeField] private bool playerInContact = false;
    [SerializeField] private Health playerHealth;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInContact = true;
            playerHealth = other.GetComponent<Health>();
            damageTimer = 0f;
            Debug.Log("hit player");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInContact = false;
            playerHealth = null;
        }
    }
    void Update()
    {
        if (playerInContact && playerHealth != null)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                playerHealth.TakeDamage(damageAmount);
                damageTimer = 0f;
            }
        }



    }

}

