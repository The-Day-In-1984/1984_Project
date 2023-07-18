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
        //Debug.Log("Idle Enter()");

    }

    public void Execute()
    {
        //Debug.Log("Idle Execute()");
        keyHorizontal = Input.GetAxisRaw("Horizontal");

        if (keyHorizontal != 0)
        {
            //Idle -> Run
            stateController.ChangeState(PLAYER_STATE.RUN);
        }
    }
    public void FixedExecute()
    {
        //Debug.Log("Idle FixedExecute()");
    }

    public void Exit()
    {
        //Debug.Log("Idle Exit()");       
    }
}
