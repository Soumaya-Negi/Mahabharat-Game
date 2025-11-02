using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI (Optional)")]
    public Slider healthBar; // assign if you have one

    private bool isInvulnerable = false;

    public void SetInvulnerable(bool value)
    {
        isInvulnerable = value;
        Debug.Log("Invulnerability set to: " + value);
    }
    private void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
            healthBar.maxValue = maxHealth;

        UpdateHealthUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
        if (isInvulnerable)
        {
            Debug.Log("Player is invulnerable! No damage taken.");
            return;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }


    private void Die()
    {
        Debug.Log("Player died!");
        // You can add respawn logic here later
    }

    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }
}
