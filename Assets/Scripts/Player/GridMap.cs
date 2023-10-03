using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    public int minGridSize = 3;             // Minimum grid size
    public int maxGridSize = 10;            // Maximum grid size
    public GameObject gridCellPrefab;       // Prefab for the grid cell
    public GameObject mountainPrefab;       // Prefab for the mountain object
    public GameObject newPrefab;          //Prefab for hte forest object
    public GameObject housePrefab;       //Prefab for a enemy house spanwer
    public GameObject borderBlockPrefab;    // Prefab for the border block
    public GameObject playerPrefab;         // Prefab for the player
    private int gridWidth;
    private int gridHeight;
    private bool[,] grid; // 2D array to represent the grid with blocked cells

    public movementtest movement;


    private float tileSize = 2.1f; // Size of each grid cell


 void Start()
    {
        gridWidth = Random.Range(minGridSize, maxGridSize + 1);
        gridHeight = Random.Range(minGridSize, maxGridSize + 1);
        grid = new bool[gridWidth, gridHeight];

        GenerateRandomGrid();

          // Instantiate the player at the center of the grid
        InstantiatePlayer();
    }

    void GenerateRandomGrid()
    {
        // Create border blocks
        CreateBorderBlocks();

        for (int x = 1; x < gridWidth - 1; x++)
    {
        for (int y = 1; y < gridHeight - 1; y++)
        {
            // Instantiate grid cell, mountain, or the new prefab based on a condition
            GameObject cellPrefab;
            float randomValue = Random.value;
            if (randomValue < 0.01f)
            {
                cellPrefab = mountainPrefab;
            }
            else if (randomValue < 0.05f)
            {
                cellPrefab = newPrefab; // Use the new prefab when randomValue is between 0.1f and 0.2f
            }
            else if(randomValue < 0.06f)
            {
                cellPrefab = housePrefab;
            }
            else
            {
                cellPrefab = gridCellPrefab;
            }

            Vector3 cellPosition = new Vector3(x * 2.1f, 0f, y * 2.1f);
            GameObject gridCell = Instantiate(cellPrefab, cellPosition, Quaternion.identity);
            gridCell.transform.parent = transform;

            // Update the grid array to mark blocked cells
            grid[x, y] = (cellPrefab == mountainPrefab);
        }
    }
    }

    void CreateBorderBlocks()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (x == 0 || x == gridWidth - 1 || y == 0 || y == gridHeight - 1)
                {
                    // Create a border block with a collider
                    Vector3 blockPosition = new Vector3(x * 2.1f, 0f, y * 2.1f);
                    GameObject borderBlock = Instantiate(borderBlockPrefab, blockPosition, Quaternion.identity);
                    borderBlock.transform.parent = transform;

                    // Add a collider to the border block
                    borderBlock.AddComponent<BoxCollider>();
                }
            }
        }
    }

        bool IsCollidingWithBorderBlock(Vector3 position)
         {
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f); // Adjust the radius as needed
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("borderblock"))
            {
                return true;
            }
        }
        return false;
        }

    void InstantiatePlayer()
        {
       // Calculate a random position within the grid
    int randomX = Random.Range(1, gridWidth - 1);
    int randomY = Random.Range(1, gridHeight - 1);

    // Calculate the position with the Y-axis offset
    float xOffset = randomX * 2.1f;
    float yOffset = 1.5f;
    float zOffset = randomY * 2.1f;
    
    Vector3 playerSpawnPosition = new Vector3(xOffset, yOffset, zOffset);

    // Instantiate the player at the adjusted position
    GameObject player = Instantiate(playerPrefab, playerSpawnPosition, Quaternion.identity);
    movement = player.GetComponent<movementtest>();

    // Set the player's grid and enable movement
    movement.SetGrid(grid);
    movement.EnableMovement();
        }
}

