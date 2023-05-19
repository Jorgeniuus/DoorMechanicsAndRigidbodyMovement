using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    private Movement movement;
    private bool isGrounded;
    private float jumpForce = 7f;

    private float maxHeight = 2f;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        JumpingForce();
    }

    private void JumpingForce()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            movement.PlayerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            MaxHeightJumpPlayer();
        }
    }

    private void MaxHeightJumpPlayer()
    {
        if (movement.PlayerRigidbody.velocity.y >= maxHeight)
        {
            movement.PlayerRigidbody.velocity = new Vector3(movement.PlayerRigidbody.velocity.x, 0, movement.PlayerRigidbody.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
