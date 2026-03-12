using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.12f;
    public Vector2 groundCheckOffset = new Vector2(0f, -0.5f);
    public LayerMask groundLayer;

    public bool canAttack;
    public Transform Aim;
    bool isWalking = false;

    public float direction = 0;

    private Rigidbody2D rb;
    private float horizInput;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        horizInput = Input.GetAxisRaw("Horizontal");

        Vector2 rayOrigin = groundCheck != null ? (Vector2)groundCheck.position : (Vector2)transform.position + groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            AudiioManager.Instance.PlaySFX(AudiioManager.Instance.jumpSFX);
        }

        if (spriteRenderer != null)
        {
            if (horizInput < -0.1f){
                spriteRenderer.flipX = false;
                direction = -1;
                }
            else if (horizInput > 0.1f) {
                spriteRenderer.flipX = true;
                direction = 1;
                }
        }

        // Update animator parameters
        if (animator != null)
        {
            animator.SetFloat("mSpeed", Mathf.Abs(horizInput));
            animator.SetBool("isGrounded", isGrounded);
        }
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizInput * speed, rb.linearVelocity.y);
        isWalking = true;

        //if(isWalking)
        //{
        //    Vector3 vector3 = vector3.Left * horizInput.x + vector3 * input.y;
        //    Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        //}
    }


    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position + (Vector3)groundCheckOffset, transform.position + (Vector3)groundCheckOffset + Vector3.down * groundCheckDistance);
        }
    }
}