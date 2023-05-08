using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
 
public class JumpState : IState
{
    private PlayerStateController stateController;
    private Rigidbody2D rigidbody;

    private readonly float jumpForce = 25f;
    private float keyHorizontal;


    public JumpState(PlayerStateController playerStateController, Rigidbody2D rigidbody2D)
    {
        this.stateController = playerStateController;
        this.rigidbody = rigidbody2D;
    }

    public void Enter()
    {
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
            stateController.ChangeState(PLAYER_STATE.RUN);
        }
    }

    public void Exit()
    {
        //Debug.Log("Jump Exit()");
    }


}
