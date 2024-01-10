using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;

    float xRotation = 0.0f;
    float yRotation = 0.0f;

    public float topClamp = -90.0f;
    public float bottomClamp = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        //locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        //get input for mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Rotation around the x axis(look up and down)
        xRotation -= mouseY;

        //clamp rotation
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //Rotation around the y axis(left and right)
        yRotation += mouseX;

        //apply rotations to our transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
    }
}
