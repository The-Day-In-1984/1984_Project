using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMoveTracker : MonoBehaviour
{
    public bool isNearLadder;
    public bool isClimbing;
    public bool isGrounded;
    [HideInInspector]
    public GameObject ladderObj;
    private CapsuleCollider2D coll;
    private LayerMask groundLayer;
     

    private void Start()
    { 
        coll = GetComponent<CapsuleCollider2D>();    
        groundLayer = LayerMask.GetMask("Ground");

    }

    private void Update()
    {
        CheckGrounded();   
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            isNearLadder = true;
            ladderObj = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            isNearLadder = false;
            ladderObj = null;
        }
    }

    private void CheckGrounded()
    {
        Bounds bounds = coll.bounds;
        Vector3 footPosition = new Vector2(bounds.center.x, bounds.min.y);
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer) ? true : false;
    }
}
