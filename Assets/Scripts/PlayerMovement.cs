using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    [SerializeField] Transform groundCheck;
    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;

    float xInput;
    bool canJump = false;

    [SerializeField] LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        if (xInput < 0)
            playerSprite.flipX = true;
        else if (xInput > 0)
            playerSprite.flipX = false;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (!OnGround()) 
                return;

            canJump = true;
        }

        Debug.DrawRay(groundCheck.transform.position, Vector2.down * 0.05f);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if (canJump)
        {
            Jump();
            canJump = false;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool OnGround()
    {
        if (Physics2D.Raycast(groundCheck.transform.position, Vector2.down, 0.05f, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
