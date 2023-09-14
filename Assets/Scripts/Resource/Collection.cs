using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class Collection : MonoBehaviour
{
      private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        // Perform actions when the player collects the item
        // For example, you can increment a score or play a sound

        // Deactivate or destroy the collectible object
        Destroy(gameObject);
        Debug.Log("Collected");
    }
}

