using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemToSpawn; // The item you want to spawn
    public Transform spawnPoint;   // The point where the item should be spawned

    public float spawnTime =0f;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // Change "Player" to the appropriate tag
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        spawnTime += Time.deltaTime;

        if(spawnTime >= 6)
        {
            if (itemToSpawn != null && spawnPoint != null)
        {
            Instantiate(itemToSpawn, spawnPoint.position, Quaternion.identity);
            spawnTime =0f;

        } 
        }
    }
}

