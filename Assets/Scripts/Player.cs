using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1.0f;
    public float airMoveAccel = 1.0f;
    public float airDrag = 200.0f;
    public float jumpSpeed = 1.0f;
    public float gravity = -10.0f;
    public bool alwaysJump = false;
    public bool alwaysUseMouse = false;
    public AnimationCurve mouseMoveCurve;
    public float rotationFactor = 1.0f;

    [Header("Other")]
    public LayerMask groundLayerMask;
    public int defaultLayer = 0;
    public int jumpingLayer = 0;
    public Transform colliderTransform;
    public Transform spriteTransform;
    public string fmodJumpEvent;

    private Rigidbody2D rb;
    private Animator animator;

    // for debugging in Editor
    private Vector2 velocity;
    private bool isGrounded;
    // ---

    private const float GroundedVelocityThreshold = 0.01f;
    private const float GroundedRaycastDistance = 0.04f;
    private const float MovementThreshold = 0.01f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        if (alwaysUseMouse || Input.GetMouseButton(0))
        {
            float mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float mouseDeltaX = mouseWorldPos - transform.position.x;
            moveDir = Mathf.Sign(mouseDeltaX) * mouseMoveCurve.Evaluate(Mathf.Abs(mouseDeltaX));
        }

        if (isGrounded)
        {
            velocity.x = moveDir * moveSpeed;

            if (alwaysJump || Input.GetButton("Jump"))
            {
                velocity.y = jumpSpeed;
                animator.SetTrigger("Jump");
                FMODUnity.RuntimeManager.PlayOneShot(fmodJumpEvent);
            }
        }
        else
        {
            if (Mathf.Abs(moveDir) > MovementThreshold)
            {
                velocity.x += moveDir * airMoveAccel * Time.deltaTime;
                velocity.x = Mathf.Clamp(velocity.x, -moveSpeed, moveSpeed);
            }
            else
            {
                // Constant deceleration
                // velocity.x = Mathf.Sign(velocity.x) * 
                //     Mathf.Max(Mathf.Abs(velocity.x) - airDecel * Time.deltaTime, 0.0f);

                // Exponential deceleration
                velocity.x *= Mathf.Pow(1.0f / airDrag, Time.deltaTime);
            }
        }

        colliderTransform.gameObject.layer = velocity.y > GroundedVelocityThreshold ? jumpingLayer : defaultLayer;
        spriteTransform.localEulerAngles = new Vector3(0.0f, 0.0f, -velocity.x * rotationFactor);

        rb.velocity = velocity;
    }
}
