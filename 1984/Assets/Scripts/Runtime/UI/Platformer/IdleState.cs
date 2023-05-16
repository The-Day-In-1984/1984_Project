using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

 
public class IdleState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;
    private float keyVertical;
    private float keyHorizontal;
    private bool keySpace;
    private GameObject ladder;
    public Vector3 playerPos;
    public Vector3 ladderPos;
    private Animator animator;

    public IdleState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody2D)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody2D;
        animator = stateController.GetComponent<Animator>();
    }

    public void Enter()
    {
        //Idle
        rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
        playerPos = stateController.transform.position;
        //Debug.Log("Idle Enter()");
        
    }

    public void Execute()
    {
        //Debug.Log("Idle Execute()");
        keyVertical = Input.GetAxisRaw("Vertical");
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        keySpace = Input.GetKey(KeyCode.Space);

        //Idle -> Jump
        if (keySpace && moveTracker.isGrounded)
        {
            stateController.ChangeState(PLAYER_STATE.JUMP);
        }
    }
    public void FixedExecute()
    {
        //Debug.Log("Idle FixedExecute()");

        if (keyHorizontal != 0)
        {
            moveTracker.isRight = keyHorizontal > 0 ? true : false; 
            //Idle -> Run
            stateController.ChangeState(PLAYER_STATE.RUN);
        }

        if (keyVertical != 0 && moveTracker.isNearLadder)
        {
            ladder = moveTracker.ladderObj;
            ladderPos = ladder.transform.position;

            //Idle -> Climb
            //down
            if (keyVertical < 0 && playerPos.y > ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.CLIMB);
             
            //up
            if (keyVertical > 0 && playerPos.y < ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.CLIMB);
        }
    }

    public void Exit()
    {
        //Debug.Log("Idle Exit()");
        
    }
}
