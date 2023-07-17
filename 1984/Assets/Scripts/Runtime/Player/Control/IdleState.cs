using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

 
public class IdleState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;
    private float keyHorizontal;
    public Vector3 playerPos;

    public IdleState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody2D)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody2D;
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
        keyHorizontal = Input.GetAxisRaw("Horizontal");
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

    }

    public void Exit()
    {
        //Debug.Log("Idle Exit()");       
    }
}
