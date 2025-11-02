using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void takeDamage(int damage)
    { 
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    public void Die()
        {
            Destroy(gameObject);
        }
}
