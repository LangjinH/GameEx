using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
{
    // Move player in 2D space
    public float startmaxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;
    public bool doublejumping;
    public bool dashing;
    public float dashSpeed = 100f;
    public float startdashtime = 0.1f;
    public float startdashCooldown = 0.05f;
    public int maxdashes = 2;
    public int maxjumps = 2;

    Vector2 movement;
    int dashes;
    float dashCooldown;
    float maxSpeed;
    float dashTime;
    bool isDashing;
    int doublejump;
    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    Animator anim;
    bool isMoving;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        isDashing = false;
        maxSpeed = startmaxSpeed;
        isMoving = false;

        if (doublejumping == true)
            doublejump = 0;
        else doublejump = maxjumps;

        if (dashing == true)
            dashes = 0;
        else dashes = maxdashes;

        dashCooldown = 0;
        

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseControl.isPaused)
        {
            // Movement controls
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
            {
                isMoving = true;
                moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            }
            else
            {
                if (isGrounded || r2d.velocity.magnitude < 0.01f)
                {
                    moveDirection = 0;
                    isMoving = false;
                }
            }

            if (isMoving == true)
            {
                anim.SetTrigger("Run");
            }

            if (isMoving == false)
            {
                anim.SetTrigger("Idle");
            }

            // Change facing direction
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x > transform.position.x && !facingRight)
            {
                flip();
            }
            else if (mousePos.x < transform.position.x && facingRight)
            {
                flip();
            }

            // Jumping
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && (isGrounded || doublejump < maxjumps - 1))
            {
                anim.SetTrigger("Jump");
                r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
                doublejump++;
            }

            //Reset DoubleJump
            if (isGrounded && doublejumping == true)
            {
                doublejump = 0;
            }

            //Dashing
            if (Input.GetKeyDown(KeyCode.LeftShift) && dashing == true && dashes < maxdashes && dashCooldown <= 0)
            {
                anim.SetTrigger("Dash");
                dashCooldown = startdashCooldown;
                dashTime = startdashtime;
                isDashing = true;
                maxSpeed = dashSpeed;
                dashes++;
            }

            if (dashCooldown > 0)
            {
                dashCooldown -= Time.deltaTime;
            }

            if (isDashing == true)
            {
                dashTime -= Time.deltaTime;

                if (dashTime <= 0)
                {
                    maxSpeed = startmaxSpeed;
                    isDashing = false;
                }
            }

            //Reset Dashes
            if (isGrounded)
            {
                dashes = 0;
            }

            // Camera follow
            if (mainCamera)
            {
                mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
            }

            //Flips the way a character is facing
            void flip()
            {
                facingRight = !facingRight;
                transform.Rotate(0f, 180f, 0f);
            }
        }
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    anim.SetTrigger("Landing");
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
    }
}
