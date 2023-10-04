using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class CameraMOvement : MonoBehaviour
{
     public float sensitivity = 1000f;
    public float xRotation = 0f;
    

    public Transform playerBody;
    public Quaternion localRotate;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float MX = Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        float MY = Input.GetAxis("Mouse Y")*sensitivity*Time.deltaTime;

        xRotation -= MY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);
        
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        localRotate = transform.localRotation;
        playerBody.Rotate(Vector3.up * MX);
    }
}
