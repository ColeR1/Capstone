using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class distancecalc : MonoBehaviour
{
    //public Transform object1; // Reference to the first object
    //public movementtest player; // Reference to the second object
    // reference to the player is movementtest.Instance;



    private void Start() {

    }

    private void Update()
    {
        ChasePlayer();
    }
    private void ChasePlayer(){
        // Check if both objects are not null
        if (movementtest.Instance != null)
        {
            // Calculate the X and Z distances between the two objects
            float xDistance = Mathf.Abs(transform.position.x - movementtest.Instance.gameObject.transform.position.x);
            float zDistance = Mathf.Abs(transform.position.z - movementtest.Instance.gameObject.transform.position.z);

            // Output the distances to the console (you can use them as needed)
            Debug.Log("X Distance: " + xDistance + ", Z Distance " + zDistance);
            if (xDistance > zDistance){
                // move the enemy in the x direction
                //transform.position.x += 1;  // might need to be negative
            }
            else{
                // move the enemy in the z direction
                //transform.position.z += 1;  // might need to be negative
            }
        }
    }
} 
