using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
      public int maxHealth = 100;       // Maximum health of the enemy
    public int currentHealth;         // Current health of the enemy

    // Called when the enemy is instantiated
    private void Start()
    {
        currentHealth = maxHealth;    // Set the initial health to the maximum health
    }

    // Method to take damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;    // Subtract damage from current health

        // Check if the enemy has run out of health
        if (currentHealth <= 0)
        {
            Die();  // If health reaches 0 or less, call the Die method
        }
    }

    // Method to handle the enemy's death (you can customize this)
    private void Die()
    {
        // Implement your death logic here, e.g., play death animation, drop items, etc.
        // For now, we'll just destroy the GameObject
        Destroy(gameObject);
    }
}
