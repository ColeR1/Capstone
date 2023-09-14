using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
     public int minGridSize = 5;    // Minimum grid size
    public int maxGridSize = 15;   // Maximum grid size
    public GameObject gridCellPrefab; // Prefab for the grid cell
    public movementtest player;  // Reference to the player's movement script

    private int gridWidth;         // Randomly generated grid width
    private int gridHeight;        // Randomly generated grid height

    void Start()
    {
        // Generate random grid size within the specified range
        gridWidth = Random.Range(minGridSize, maxGridSize + 1);
        gridHeight = Random.Range(minGridSize, maxGridSize + 1);

        // Update the player's gridWidth and gridHeight
        if (player != null)
        {
            player.gridWidth = gridWidth;
            player.gridHeight = gridHeight;
        }

        // Create the random grid
        CreateRandomGrid();
    }

    void CreateRandomGrid()
    {
        for (int x = 0; x < gridWidth; x++)
    {
        for (int z = 0; z < gridHeight; z++)
        {
            Vector3 cellPosition = new Vector3(x * 2.1f, 0f, z * 2.1f);
            GameObject gridCell = Instantiate(gridCellPrefab, cellPosition, Quaternion.identity);
            gridCell.transform.parent = transform;
        }
    }
    }
}
