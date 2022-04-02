using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float airMoveAccel = 1.0f;
    public float jumpSpeed = 1.0f;
    public float gravity = -10.0f;
    public bool alwaysJump = false;
    public LayerMask groundLayerMask;
    public int defaultLayer = 0;
    public int jumpingLayer = 0;
    public Transform colliderTransform;

    private Rigidbody2D rb;

    // for debugging in Editor
    private Vector2 velocity;
    private bool isGrounded;
    // ---

    private const float GroundedVelocityThreshold = 0.01f;
    private const float GroundedRaycastDistance = 0.04f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        velocity = rb.velocity;

        // Check if we're touching the ground
        isGrounded = false;
        if (velocity.y < GroundedVelocityThreshold)
        {
            var groundHit = Physics2D.BoxCast(
                colliderTransform.position, colliderTransform.lossyScale, 
                0f, Vector2.down, GroundedRaycastDistance, 
                groundLayerMask
            );
            isGrounded = (groundHit.collider != null);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Handle manual movement
        float moveDir = Input.GetAxisRaw("Horizontal");
        if (isGrounded)
        {
            velocity.x = moveDir * moveSpeed;

            if (alwaysJump || Input.GetButton("Jump"))
            {
                velocity.y = jumpSpeed;
            }
        }
        else
        {
            velocity.x += moveDir * airMoveAccel * Time.deltaTime;
            velocity.x = Mathf.Clamp(velocity.x, -moveSpeed, moveSpeed);
        }

        colliderTransform.gameObject.layer = velocity.y > GroundedVelocityThreshold ? jumpingLayer : defaultLayer;

        rb.velocity = velocity;
    }
}
