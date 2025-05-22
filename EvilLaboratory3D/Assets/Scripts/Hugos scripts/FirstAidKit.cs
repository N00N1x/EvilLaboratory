using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] public int healAmount = 50;
    [SerializeField] private bool playerInRange = false;
    [SerializeField] private Health playerHealth;
    [SerializeField] private GameObject uiPrompt;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerHealth = other.GetComponent<Health>();
            if (uiPrompt != null)
                uiPrompt.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerHealth = null;

            if (uiPrompt != null)
                uiPrompt.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                if (uiPrompt != null)
                    uiPrompt.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
