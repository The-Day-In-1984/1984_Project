using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
 
public class ClimbState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;
    private readonly float climbSpeed = 15f;
    private float keyVertical;
    private GameObject ladder;
    public Vector3 ladderPos;
    public Vector3 playerPos;
    private Animator animator;

    public ClimbState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody2D)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody2D;
        animator = stateController.GetComponent<Animator>();
    }

    public void Enter()
    {
        Debug.Log("Climb Enter()");
        animator.SetBool("isClimbing", true);
        ladder = moveTracker.ladderObj;
        ladderPos = ladder.transform.position;

        //rigidbody, position 조정
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        rigidbody.velocity = Vector2.zero;
        playerPos = stateController.transform.position;
        Vector3 startPos;

        if (playerPos.x <= ladderPos.x)
        {
            startPos = new Vector3(ladderPos.x - 1.0f, playerPos.y, 0);
        }
        else
        {
            startPos = new Vector3(ladderPos.x + 1.0f, playerPos.y, 0);
        }
        stateController.transform.position = Vector3.MoveTowards(playerPos, startPos, 3.0f);

    }

    public void Execute()
    {
        Debug.Log("Climb Execute()");
        keyVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            //Climb -> Jump
            stateController.ChangeState(PLAYER_STATE.JUMP);
        }
 
    }

    public void FixedExecute()
    {
        if (keyVertical == 0)
        {
            //Stop
            rigidbody.velocity = new Vector2(0f, 0f);
        }
        else
        {
            //Climb
            Vector2 climbVelocity = new Vector2(0f, keyVertical * climbSpeed);
            rigidbody.velocity = climbVelocity;
        }

        if (moveTracker.isGrounded)
        {
            playerPos = stateController.transform.position;

            //End of Climbing down
            if (keyVertical < 0 && playerPos.y < ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.IDLE);

            //End of Climbing up
            if (keyVertical > 0 && playerPos.y > ladderPos.y)
                stateController.ChangeState(PLAYER_STATE.IDLE);
        }
    }

    public void Exit()
    {
        Debug.Log("Climb Exit()");
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        animator.SetBool("isClimbing", false);
    }
}