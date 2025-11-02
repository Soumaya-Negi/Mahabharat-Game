using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage = 15f;
    public float knockbackForce = 5f;
    public PlayerMovement owner;
    public float lifeTime = 3f;
    public LayerMask enemyLayer;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemyLayer) != 0)
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
                enemyHealth.TakeDamage(damage, knockbackDir, knockbackForce);
            }
        }

        // Don't destroy if it hits the player or its own collider
        if (owner != null && collision.gameObject == owner.gameObject)
            return;

        Destroy(gameObject);
    }
}
