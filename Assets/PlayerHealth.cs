using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;           // Maximum health of the player
    public int currentHealth;             // Current health of the player
   

    private void Start()
    {
        currentHealth = maxHealth;        // Set the initial health to the maximum health
     
    }

    // Method to take damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;    // Subtract damage from current health
        currentHealth = Mathf.Max(0, currentHealth); // Ensure health doesn't go below 0
        if (currentHealth <= 0)
        {
            Die();                       // If health reaches 0 or less, call the Die method
        }
    }

    // Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;      // Add healing to current health
        currentHealth = Mathf.Min(maxHealth, currentHealth); // Ensure health doesn't exceed maxHealth
    }



    // Method to handle the player's death (you can customize this)
    private void Die()
    {
        // Implement your death logic here, e.g., play death animation, respawn, etc.
        // For now, we'll just disable the GameObject
        gameObject.SetActive(false);
    }
}
