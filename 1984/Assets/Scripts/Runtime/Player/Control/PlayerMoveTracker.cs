using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveTracker : MonoBehaviour
{
    [Header("Move Setting")]
    public float runSpeed = 20.0f;

    [HideInInspector] public bool isTraces;
    private CapsuleCollider2D coll;
    private LayerMask groundLayer;
    


    private void Start()
    { 
        coll = GetComponent<CapsuleCollider2D>(); 
        groundLayer = LayerMask.GetMask("Ground");
    }

}
