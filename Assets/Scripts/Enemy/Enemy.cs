using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
     public float detectionRange = 10f;
    public float moveSpeed = 3f;

    private Transform player;
    private bool isFollowingPlayer = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Assuming the player has the "Player" tag.
    }

    private void Update()
    {
        if (!isFollowingPlayer)
        {
            // Check if the player is within detection range
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= detectionRange)
            {
                isFollowingPlayer = true;
            }
        }
        else
        {
            // Follow the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);

            // Check if the player is out of range
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer > detectionRange)
            {
                isFollowingPlayer = false;
            }
        }
    }
}
