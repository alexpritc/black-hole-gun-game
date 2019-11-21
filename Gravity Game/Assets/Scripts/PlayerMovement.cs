using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 7.5f;
    private float distanceToGround = 1.2f;
    private float gravity = -9.85f;
    private float jumpHeight = 2f;

    private Vector3 velocity;
    private Vector3 down;
    private Vector3 move;

    private CharacterController cc;

    private bool isGrounded;

    private RaycastHit hit;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        isGrounded = true;
    }

    // Update is called once per frame.
    // Player input.
    void Update()
    {
        // Get jump input.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jump!");

            isGrounded = false;
        }

        // Get movement input.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Local movement according to player's rotation.
        move = transform.right * x + transform.forward * z;

        // Apply gravity to velocity.
        velocity.y += gravity * Time.deltaTime;
    }

    // Physics.
    void FixedUpdate()
    {
        // Play footstep sounds here.
        cc.Move(move * speed * Time.deltaTime);

        // Play jump sound here.
        cc.Move(velocity * Time.deltaTime);
        GroundCheck();
    }

    void GroundCheck()
    {
        // Draw raycast downwards to check if the player is touching the ground.
        down = transform.TransformDirection(Vector3.down);

        Debug.DrawRay(transform.position, down, Color.red);

        if (Physics.Raycast(transform.position, down, out hit, distanceToGround))
        {
            Debug.DrawRay(transform.position, down * hit.distance, Color.yellow);
            isGrounded = true;
            velocity.y = 0f;
        }
    }
}
