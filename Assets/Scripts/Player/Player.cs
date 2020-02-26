using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EntityBaseClass
{
    [Header("Jumping Physics")]
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [Header("Movement Physics")]
    public float movementSmoothing = .05f;

    [Header("In-game constants")]
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;
    private CapsuleCollider2D collider;
    public LayerMask groundLayer;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        //Moving physics
        float move = Input.GetAxis("Horizontal");
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);

        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
        
        if (move > 0 && !facing_right)
        {
            Flip();
        }
        else if (move < 0 && facing_right)
        {
            Flip();
        }
        // Debug.Log(IsGrounded());
        //Jumping physics
        if (Input.GetButton("Jump") && IsGrounded())
        {
            rb.velocity += Vector2.up * jumpforce;
        }
        
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast(collider.bounds.center, Vector2.down, collider.bounds.extents.y + .05f, groundLayer);
        return raycastHit.collider != null;
    }
}
