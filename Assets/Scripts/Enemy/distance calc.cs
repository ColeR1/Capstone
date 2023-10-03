using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class distancecalc : MonoBehaviour
{
    //public Transform object1; // Reference to the first object
    public movementtest player; // Reference to the second object

    private void OnAwake()
    {
        player = movementtest.Instance; //.GameObject.Transform;
    }

    private void Update()
    {
        ChasePlayer();
    }
    private void ChasePlayer(){
        // Check if both objects are not null
        if (player != null)
        {
            // Calculate the X and Z distances between the two objects
            float xDistance = 1; //Mathf.Abs(transform.position.x - player.position.x);
            float zDistance = 4; //Mathf.Abs(transform.position.z - player.position.z);

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
