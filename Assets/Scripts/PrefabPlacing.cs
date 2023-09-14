using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
  public GameObject prefabToSpawn; // The prefab to spawn on the clicked object
    public float verticalOffset = 1.0f; // The vertical offset from the object's position


    void Update()
    {

            // Check for a mouse click
             if(Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
            {
                // Create a ray from the camera to the mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Perform the raycast
                if (Physics.Raycast(ray, out hit))
                {
                    // Get the GameObject that was hit
                    GameObject clickedObject = hit.collider.gameObject;

                    // Check if the clicked object is valid for spawning (e.g., terrain, walls)
                    if (IsValidObjectForSpawn(clickedObject))
                    {
                        // Spawn the prefab as a child of the clicked object with a vertical offset
                        SpawnPrefab(clickedObject);
                    }
                }
            }  
    }

    bool IsValidObjectForSpawn(GameObject obj)
    {
        // Add conditions to check if the object is valid for spawning (e.g., not a UI element)
        // You can customize this function based on your requirements
        return true;
    }

    void SpawnPrefab(GameObject parentObject)
    {
        if (prefabToSpawn != null)
        {
            // Calculate the spawn position with the vertical offset
            Vector3 spawnPosition = parentObject.transform.position + Vector3.up * verticalOffset;

            // Instantiate the prefab as a child of the parent object at the calculated position
            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity, parentObject.transform);
        }
    }
}


