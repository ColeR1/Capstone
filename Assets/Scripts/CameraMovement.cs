using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  public float speed = 10.0f;

    void Update()
    {
        // for getting input from WASD keys
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // for moving camera based on input
        transform.position += new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
    }
}
