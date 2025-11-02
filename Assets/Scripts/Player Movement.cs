using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform FirePoint;
    public float arrowForce = 10f;
    public enum PandavClass { Bheem, Arjun, Yudhishthir, Nakul, Sahdev }
    public PandavClass currentPandav;

    [Header("General Movement")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool facingRight = true;

    [Header("Combat Settings")]
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayer;

    [Header("Pandav Settings")]

    public float bheemPunchDamage = 20f;
    public float bheemPunchForce = 6f;

    [Header("VFX and SFX")]
    public ParticleSystem bheemPunchEffect;
    public AudioClip bheemPunchSound;

    public ParticleSystem arjunShootEffect;
    public AudioClip arjunShootSound;

    private AudioSource audioSource;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        HandleMovement();
        HandleFlip();
        PerformAttack();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveInput * moveSpeed;
    }

    void HandleFlip()
    {
        if (facingRight && moveInput.x < 0)
        {
            Flip();
        }
        else if (!facingRight && moveInput.x > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void PerformAttack()
    {
        // Left-click = Attack for current Pandav
        if (Input.GetMouseButtonDown(0))
        {
            switch (currentPandav)
            {
                case PandavClass.Bheem:
                    BheemPunch();
                    break;
                case PandavClass.Arjun:
                    ArjunShoot();
                    break;
                default:
                    // Future Pandavs can go here
                    break;
            }
        }
    }

    void BheemPunch()
    {
        Debug.Log("Bheem Punch Activated!");

        // 🔹 Play visual effect
        if (bheemPunchEffect != null)
            Instantiate(bheemPunchEffect, attackPoint.position, Quaternion.identity);

        // 🔹 Play sound effect
        if (bheemPunchSound != null)
            audioSource.PlayOneShot(bheemPunchSound);

        // 🔹 Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Direction and force of the punch knockback
                Vector2 knockbackDir = (enemy.transform.position - transform.position).normalized;
                float knockbackForce = 7f;

                // Apply damage + knockback through your existing system
                enemyHealth.TakeDamage(20f, knockbackDir, knockbackForce);

                Debug.Log($"Bheem punched {enemy.name} for 20 damage!");
            }
        }
    }



    void ArjunShoot()
    {
        if (arrowPrefab == null || FirePoint == null)
        {
            Debug.LogWarning("Arrow prefab or fire point missing!");
            return;
        }

        // 🔹 Play sound & effect
        if (arjunShootEffect != null)
            Instantiate(arjunShootEffect, FirePoint.position, Quaternion.identity);

        if (arjunShootSound != null)
            audioSource.PlayOneShot(arjunShootSound);

        // 🔹 Create arrow
        GameObject arrowObj = Instantiate(arrowPrefab, FirePoint.position, Quaternion.identity);

        // Direction toward cursor
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - FirePoint.position).normalized;

        Rigidbody2D rb = arrowObj.GetComponent<Rigidbody2D>();
        rb.velocity = direction * 10f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrowObj.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Assign shooter info
        Arrow arrow = arrowObj.GetComponent<Arrow>();
        if (arrow != null)
        {
            arrow.damage = 15f;
            arrow.knockbackForce = 5f;
            arrow.owner = this;
        }

        Debug.Log("Arjun shot an arrow!");
    }



    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
