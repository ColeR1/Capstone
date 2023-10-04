using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
      public float attackCooldown = 1f;  // Time in seconds between each attack
    public int damageAmount = 10;      // Amount of damage the enemy deals to the player

    private PlayerHealth playerhealth;  // Reference to the player's health script
    private float lastAttackTime;      // Time when the last attack occurred

    private void Start()
    {
        playerhealth = FindObjectOfType<PlayerHealth>(); // Find the PlayerHealth script in the scene
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
            
            // Check if enough time has passed since the last attack
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time; // Update the last attack time
            }
        }
    }

    private void AttackPlayer()
    {
        if (playerhealth != null)
        {
            playerhealth.TakeDamage(damageAmount); // Deal damage to the player
        }
    }
}
