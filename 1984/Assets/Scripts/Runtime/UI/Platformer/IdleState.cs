using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class IdleState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;
    private float keyVertical;
    private float keyHorizontal;
    private bool keySpace;
    private GameObject ladder;
    public Vector3 nowPos;
    public Vector3 ladderPos;

    public IdleState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody2D)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody2D;
    }

    public void Enter()
    {
        // Idle 애니메이션 실행
        Debug.Log("Idle Enter()");
        rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
    }

    public void Execute()
    {
        keyVertical = Input.GetAxisRaw("Vertical");
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        keySpace = Input.GetKey(KeyCode.Space);
        nowPos = stateController.transform.position;
        Debug.Log("Idle Execute()");

        if (keySpace && moveTracker.isGrounded)
        {
            stateController.ChangeState(PLAYER_STATE.JUMP);
        }
    }
    public void FixedExecute()
    {
        Debug.Log("Idle FixedExecute()");
        // 캐릭터가 움직이지 않을 때 수행할 작업

        if (keyHorizontal != 0)
        {
            stateController.ChangeState(PLAYER_STATE.RUN);
        }

        if (keyVertical != 0 && moveTracker.isNearLadder)
        {
            ladder = moveTracker.ladderObj;
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
        Debug.Log("Idle Exit()");
        // Idle 애니메이션 정지
    }
}
