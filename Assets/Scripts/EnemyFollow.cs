using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float stopDistance = 1.5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            // Move towards player
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
        }
    }

    public void Knockback(Vector2 direction, float force)
    {
        if (rb != null)
        {
            StartCoroutine(KnockbackRoutine(direction, force));
        }
    }

    private System.Collections.IEnumerator KnockbackRoutine(Vector2 direction, float force)
    {
        float duration = 0.15f;
        float timer = 0f;

        while (timer < duration)
        {
            rb.MovePosition(rb.position + direction * force * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
