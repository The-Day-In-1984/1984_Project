using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
 
public class JumpState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;

    private readonly float jumpForce = 25f;
    private float keyHorizontal;

    private Animator animator;


    public JumpState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody2D)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody2D;
        animator = stateController.GetComponent<Animator>();
    }

    public void Enter()
    {
        animator.SetTrigger("isJumping");
        //Jump
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        //Debug.Log("Jump Enter()");
        
    }

    public void Execute()
    {
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log("Jump Execute()");
    }

    public void FixedExecute() 
    {        
        //Jump -> Idle
        if (rigidbody.velocity.y == 0)
        {
            stateController.ChangeState(PLAYER_STATE.IDLE);
        }

        //Jump -> Run
        if (keyHorizontal!=0)
        {
            moveTracker.isRight = keyHorizontal > 0 ? true : false;
            stateController.ChangeState(PLAYER_STATE.RUN);
        }
    }

    public void Exit()
    {
        //Debug.Log("Jump Exit()");
    }


}
