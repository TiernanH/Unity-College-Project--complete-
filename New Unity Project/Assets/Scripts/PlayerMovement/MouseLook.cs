using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public GameManager gameManagerScr;
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    void Start()
    {
        //locking the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        //retrieveing tbhe gameManager script
        gameManagerScr = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        //so long as the game isn't paused
        if (!gameManagerScr.getIsPaused())
        {
            //get x and y input of the mouse
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            //set rotations and clamp the value
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            //rotate camera in the local x direction (Up/Down)
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            //rotate the player on the global y axis (Left/Right)
            playerBody.Rotate(Vector3.up * mouseX);
        }
        
    }
}
