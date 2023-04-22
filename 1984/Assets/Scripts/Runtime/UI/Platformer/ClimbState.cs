using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ClimbState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;
    private CapsuleCollider2D collider;
    private readonly float climbSpeed = 5f;
    private float keyVertical;
    private GameObject ladder;
    public Vector3 ladderPos;
    public Vector3 nowPos;

    public ClimbState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody;
    }

    public void Enter()
    {
        Debug.Log("Climb Enter()");
        moveTracker.isClimbing = true;
        ladder = moveTracker.ladder;
        // Climb 애니메이션 실행
        //ladder = characterStateManager.playerMove.ladder;
        ladderPos = ladder.transform.position;

        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;
        nowPos = stateController.transform.position;
        stateController.transform.position = Vector3.MoveTowards(nowPos, new Vector3(ladderPos.x, nowPos.y, 0), 0.6f);

    }

    public void Execute()
    {
        Debug.Log("Climb Execute()");
        keyVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            stateController.ChangeState(PLAYER_STATE.JUMP);
        }
    }

    public void FixedExecute()
    {
        //
        if (keyVertical == 0)
        {
            rigidbody.velocity = new Vector2(0f, 0f);
        }
        else
        {
            nowPos = stateController.transform.position;

            Vector2 climbVelocity = new Vector2(0f, keyVertical * climbSpeed);
            rigidbody.velocity = climbVelocity;
        }

        if (moveTracker.isGrounded)
        {
            //내려감
            if (keyVertical < 0 && nowPos.y < ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.IDLE);

            //올라감
            if (keyVertical > 0 && nowPos.y > ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.IDLE);
        }
    }

    public void Exit()
    {
        Debug.Log("Climb Exit()");
        // Climb 애니메이션 정지
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        stateController.playerMoveTracker.isClimbing = false;

    }
}