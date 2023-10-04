using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementtest : MonoBehaviour
{ 
   public float moveSpeed = 5.0f;  // Movement speed
    public float tileSize = 2.1f;   // Size of each grid tile
    private int gridWidth;
    private int gridHeight;
    private bool[,] grid; // Reference to the grid with blocked cells

    private Vector3 targetPosition;

    private bool isMoving = false; // Flag to check if the player is currently moving
    private bool canMove = true;  // Flag to control player movement

    public static movementtest Instance{get; private set;}

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        //Instance = this;
        targetPosition = transform.position;
    }

    void Update()
    {
        if (canMove && !isMoving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                TryMove(Vector3.left);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                TryMove(Vector3.right);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                TryMove(Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                TryMove(Vector3.back);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void TryMove(Vector3 direction)
    {
        Vector3 newTargetPosition = targetPosition + direction * tileSize;

        // Calculate the grid cell indices for the new position
        int x = Mathf.FloorToInt(newTargetPosition.x / tileSize);
        int y = Mathf.FloorToInt(newTargetPosition.z / tileSize);

        // Check if the new position is within grid bounds, not blocked, and not on a border block
        if (IsValidMove(x, y) && !IsOnBorderBlock(newTargetPosition))
        {
            StartCoroutine(MoveCoroutine(newTargetPosition));
        }
    }

    bool IsValidMove(int x, int y)
    {
        // Check if the new position is within the grid bounds and not blocked
        return x >= 0 && x < gridWidth && y >= 0 && y < gridHeight && !grid[x, y];
    }

    bool IsOnBorderBlock(Vector3 position)
    {
        // Perform a raycast to check if the player is on a border block
        RaycastHit hit;
        if (Physics.Raycast(position + Vector3.up * 0.5f, Vector3.down, out hit))
        {
            return hit.collider.CompareTag("borderblock"); // Adjust the tag as needed
        }

        return false;
    }

    IEnumerator MoveCoroutine(Vector3 destination)
    {
        isMoving = true; // Set the flag to indicate that the player is moving

        float journeyLength = Vector3.Distance(targetPosition, destination);
        float startTime = Time.time;

        while (Time.time < startTime + 0.3f)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distanceCovered / journeyLength;

            targetPosition = Vector3.Lerp(targetPosition, destination, fractionOfJourney);

            yield return null;
        }

        targetPosition = destination;
        isMoving = false; // Reset the flag to indicate that the player has stopped moving
        yield return null;
    }

    public void SetGrid(bool[,] newGrid)
    {
        grid = newGrid;
        gridWidth = grid.GetLength(0);
        gridHeight = grid.GetLength(1);
    }

    // Call this function to enable player movement
    public void EnableMovement()
    {
        canMove = true;
    }

    // Call this function to disable player movement
    public void DisableMovement()
    {
        canMove = false;
    }
}
