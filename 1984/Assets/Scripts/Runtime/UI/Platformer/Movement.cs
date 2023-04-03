using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float maxSpeed = 5.0f;
    [SerializeField] private float jumpForce = 15.0f;
    private float idleGravity = 7.0f;
    private float longJumpGravity = 4.0f;
    private Rigidbody2D rigid2D;

    [Header("GroundCheck")]
    [SerializeField] private LayerMask groundLayer; 
    private CapsuleCollider2D capsuleCollider2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * maxSpeed, rigid2D.velocity.y);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            rigid2D.velocity = Vector2.up * jumpForce;
        }

    }

    public void LongJump(bool isLongJump)
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

    private bool IsGrounded()
    {
        Bounds bounds = capsuleCollider2D.bounds;
        Vector3 footPosition = new Vector2(bounds.center.x, bounds.min.y);

        return Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);
    }
}
