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

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    public LayerMask groundLayer;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        
        

        
        
        
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

        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + .05f, groundLayer);
        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.green;
        }else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + .05f), Color.green);

        return raycastHit.collider != null;

    }




}
