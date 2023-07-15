using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
 
public class RunState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;
    private float keyHorizontal;
    private Vector3 playerPos;
    private Vector3 playerScale;
    private float speed;

    public RunState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody2D)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody2D;
    }

    public void Enter()
    {
        //Debug.Log("Run Enter()");
        speed = moveTracker.runSpeed;

        playerPos = stateController.transform.position;
        stateController.transform.localScale = moveTracker.isRight? new Vector3(1f, 1f, 1f): new Vector3(-1f, 1f, 1f);
        playerScale = new Vector3(1f, 1f, 1f);
    }

    public void Execute()
    {
        //Debug.Log("Run Execute()");
        keyHorizontal = Input.GetAxisRaw("Horizontal");
    }

    public void FixedExecute()
    {
        if (keyHorizontal != 0)
        {
            //Run           
            rigidbody.velocity = new Vector2(keyHorizontal * speed, rigidbody.velocity.y);
        }

        else
        {
            //Idle
            rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
            stateController.ChangeState(PLAYER_STATE.IDLE);
        }

    }

    public void Exit()
    {
        //Debug.Log("Run Exit()");
    }
}