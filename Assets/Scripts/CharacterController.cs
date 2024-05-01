using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character movement
    public float jumpForce = 10f; // Force applied when jumping
    public Transform groundCheck; // Transform representing the ground check position
    public LayerMask groundMask; // Layer mask to determine what is considered ground

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        // Player input for movement
        float moveInput = Input.GetAxis("Horizontal");
        float jumpInput = Input.GetAxis("Jump");

        // Calculate movement direction
        Vector3 moveDirection = transform.right * moveInput;

        // Apply movement
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

        // Jumping
        if (isGrounded && jumpInput > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
