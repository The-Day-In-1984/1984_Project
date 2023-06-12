using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
 
public class RunState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;
    private readonly float moveSpeed = 20f;
    private float keyHorizontal;
    private float keyVertical;
    private Vector3 playerPos;
    private Vector3 playerScale;

    private GameObject ladder;
    public Vector3 ladderPos;

    public RunState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody2D)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody2D;
    }

    public void Enter()
    {
        //Debug.Log("Run Enter()");
        playerPos = stateController.transform.position;
        stateController.transform.localScale = moveTracker.isRight? new Vector3(1f, 1f, 1f): new Vector3(-1f, 1f, 1f);
        playerScale = new Vector3(1f, 1f, 1f);
    }

    public void Execute()
    {
        //Debug.Log("Run Execute()");
        keyVertical = Input.GetAxisRaw("Vertical");
        keyHorizontal = Input.GetAxisRaw("Horizontal");

        //Run -> Jump
        if (Input.GetKey(KeyCode.Space) && moveTracker.isGrounded)
        {
            stateController.ChangeState(PLAYER_STATE.JUMP);
        }
    }

    public void FixedExecute()
    {
        if (keyHorizontal != 0)
        {
            //Run           
            rigidbody.velocity = new Vector2(keyHorizontal * moveSpeed, rigidbody.velocity.y);
        }

        else
        {
            //Idle
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            stateController.ChangeState(PLAYER_STATE.IDLE);
        }

        if (keyVertical != 0 && moveTracker.isNearLadder)
        {
            ladder = moveTracker.ladderObj;
            ladderPos = ladder.transform.position;

            //Climb down
            if (keyVertical < 0 && playerPos.y > ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.CLIMB);

            //Climb up
            if (keyVertical > 0 && playerPos.y < ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.CLIMB);

        }
    }

    public void Exit()
    {
        //Debug.Log("Run Exit()");
    }
}