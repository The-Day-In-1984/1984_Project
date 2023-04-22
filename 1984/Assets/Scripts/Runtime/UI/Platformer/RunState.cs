using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class RunState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;
    private readonly float moveSpeed = 5f;
    private float keyHorizontal;
    private float keyVertical;
    private bool keySpace;
    public Vector3 nowPos;
    private GameObject ladder;
    public Vector3 ladderPos;

    public RunState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody;
    }

    public void Enter()
    {
        Debug.Log("Run Enter()");
        // Run 애니메이션 실행

    }

    public void Execute()
    { 
        keyVertical = Input.GetAxisRaw("Vertical");
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        keySpace = Input.GetKey(KeyCode.Space);
        Debug.Log("Run Execute()");
         
        if (keySpace && moveTracker.isGrounded)
        {
            stateController.ChangeState(PLAYER_STATE.JUMP);
        }
    }

    public void FixedExecute()
    {
        if (keyHorizontal != 0)
        {
            nowPos = stateController.transform.position;
            keyHorizontal = Input.GetAxisRaw("Horizontal");

            Vector2 runVelocity = new Vector2(keyHorizontal * moveSpeed, rigidbody.velocity.y);
            rigidbody.velocity = runVelocity;

        }
        else if (keyHorizontal == 0)
        {
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            stateController.ChangeState(PLAYER_STATE.IDLE);
        }

        if (keyVertical != 0 && moveTracker.isNearLadder && !moveTracker.isClimbing)
        {
            ladder = moveTracker.ladder;
            ladderPos = ladder.transform.position;

            //내려감
            if (keyVertical < 0 && nowPos.y > ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.CLIMB);

            //올라감
            if (keyVertical > 0 && nowPos.y < ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.CLIMB);

        }
    }

    public void Exit()
    {
        // Run 애니메이션 정지
        Debug.Log("Run Exit()");

    }
}