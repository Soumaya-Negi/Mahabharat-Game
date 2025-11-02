using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;
    private Rigidbody2D rb;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage, Vector2 knockbackDir, float knockbackForce)
    {
        currentHealth -= damage;

        // Knockback only when hit
        rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
