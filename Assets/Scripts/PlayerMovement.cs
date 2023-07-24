using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D groundColl;
    private Animator animator;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private float jumpHeigh = 20f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int maxJump = 1;
    [SerializeField] private int jumpCount = 0;
    private float dirX;

    private enum MovementState { idle, running, jumping, falling, doubleJump}
    private MovementState state = MovementState.idle;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        groundColl = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        PlayerMove();

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (playerRigidbody.velocity.y > .1f)
        {

            state = MovementState.jumping;
        }
        else if (playerRigidbody.velocity.y < -.1f)
        {

            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private void PlayerMove()
    {
        HorizontalMovement();
        Jump();
    }

    private void Jump()
    {
    if (Input.GetButtonDown("Jump"))
        {
            bool jumpable = false;
            if (jumpCount < maxJump)
            {
                jumpable = true;
            }
            else
            {
                if (IsGrounded())
                {
                    jumpable = true;
                    jumpCount = 0;
                }
            }

            if (jumpable) 
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeigh);
                jumpCount++;
            }
        }
    }

    private void HorizontalMovement()
    {
        // get the Axis of "Horizontal" vitural button set in Unity
        // return 1 if right and -1 if left
        dirX = Input.GetAxisRaw("Horizontal");
        float runSpeed = moveSpeed * dirX;

        playerRigidbody.velocity = new Vector2(runSpeed, playerRigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(groundColl.bounds.center, groundColl.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
