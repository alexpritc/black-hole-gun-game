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

    private CharacterController cc;

    private bool isGrounded;

    private RaycastHit hit;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame.
    void FixedUpdate()
    {
        down = transform.TransformDirection(Vector3.down);

        Debug.DrawRay(transform.position, down, Color.red);

        if (Physics.Raycast(transform.position, down, out hit, distanceToGround))
        {
            Debug.DrawRay(transform.position, down * hit.distance, Color.yellow);
            isGrounded = true;
            velocity.y = 0f;
        }
        else
        {
            isGrounded = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Local movement according to player's rotation.
        Vector3 move = transform.right * x + transform.forward * z;

        cc.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        cc.Move(velocity * Time.deltaTime);

        // Play footstep sounds here.
    }
}
