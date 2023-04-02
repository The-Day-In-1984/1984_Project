using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 5.0f;
    [SerializeField]
    private float jumpForce = 15.0f;
    private float idleGravity = 7.0f;
    private float longJumpGravity = 4.0f;
    private Rigidbody2D rigid2D;


    [SerializeField]
    private LayerMask groundLayer; 
    private CapsuleCollider2D capsuleCollider2D;
    private Vector3 footPosition; 

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    public void Move(float X)
    {
        rigid2D.velocity = new Vector2(X * maxSpeed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if (isGrounded())
        {
            rigid2D.velocity = Vector2.up * jumpForce;
        }

    }

    public void isLongJump(bool isLongJump)
    {
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = longJumpGravity;
        }
        else
        {
            rigid2D.gravityScale = idleGravity;
        }
    }

    private bool isGrounded()
    {
        Bounds bounds = capsuleCollider2D.bounds;
        footPosition = new Vector2(bounds.center.x, bounds.min.y);

        return Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);
    }
}
