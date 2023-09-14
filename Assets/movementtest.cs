using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementtest : MonoBehaviour
{ 
     public float moveSpeed = 5.0f;  // Movement speed
    public float tileSize = 2.1f;   // Size of each grid tile
    public int gridWidth = 5;       // Number of tiles in the X-axis
    public int gridHeight = 5;      // Number of tiles in the Z-axis

    private Vector3 targetPosition;  // The target position to move towards
    private bool canMove = true;     // Flag to control player movement

    void Start()
    {
        // Initialize the target position to the current position
        targetPosition = transform.position;
    }

    void Update()
    {
        if (canMove)
        {
            // Check for input to move the player
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Move(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Move(Vector3.right);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Move(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Move(Vector3.back);
            }
        }

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void Move(Vector3 direction)
    {
        // Calculate the new target position based on the grid size
        Vector3 newTargetPosition = targetPosition + direction * tileSize;

        // Check if the new target position is within the grid boundaries
        if (IsValidMove(newTargetPosition))
        {
            targetPosition = newTargetPosition;
            canMove = false; // Disable movement until reaching the target
            StartCoroutine(WaitForMovement());
        }
    }

    bool IsValidMove(Vector3 position)
    {
        // Check if the position is within the grid boundaries
        if (position.x >= 0 && position.x < gridWidth * tileSize &&
            position.z >= 0 && position.z < gridHeight * tileSize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator WaitForMovement()
    {
        yield return new WaitForSeconds(0.3f); // Wait for 1 second
        canMove = true; // Enable movement after waiting
    }
}
