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
    private float speed;
    private readonly Vector3 _localScaleR = new(1f, 1f, 1f);
    private readonly Vector3 _localScaleL = new(-1f, 1f, 1f);

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
    }

    public void Execute()
    {
        //Debug.Log("Run Execute()");
        keyHorizontal = Input.GetAxisRaw("Horizontal");


    }

    public void FixedExecute()
    {
        if (keyHorizontal > 0)
        {
            stateController.transform.localScale = _localScaleR;
        }
        else if (keyHorizontal < 0)
        {
            stateController.transform.localScale = _localScaleL;
        }
        else
        {
            //Idle
            stateController.ChangeState(PLAYER_STATE.IDLE);
        }

        //Run
        rigidbody.velocity = new Vector2(keyHorizontal * speed, rigidbody.velocity.y);
    }


        public void Exit()
    {
        //Debug.Log("Run Exit()");
    }
}