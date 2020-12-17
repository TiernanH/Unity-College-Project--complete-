using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public CharacterController controller;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public float speed = 12f;
    private float gravity = -9.81f * 3;
    private float jumpHeight = 2;
    public Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    private GameManager gameManagerScr;

    private void Start()
    {
        //retieveing the GameManager script
        gameManagerScr = GameObject.Find("GameManager").GetComponent<GameManager>();
        //get the player's audiosource
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //if the game is not paused
        if (!gameManagerScr.getIsPaused()) 
        {
            //check if it is on the ground
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            //if that check is true and velocity is nothing then keep it on the ground
            if (isGrounded && velocity.y < 0) { velocity.y = -2f; }

            //get x and y inputs from keyboard
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            //move the game controller based on those inputs
            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            controller.Move(move * speed * Time.deltaTime);
                
            //if "SPACE" is pressed and player is on the ground and game is not paused
            if (Input.GetButtonDown("Jump") && isGrounded && !gameManagerScr.getIsPaused())
            {
                //play the jump sound
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                //this equation adds an upward force
                //resulting in a consistant height regardless of gravity
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            //increase velocity by the gravity. Always
            velocity.y += gravity * Time.deltaTime;
            //move player controller by that velocity
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
