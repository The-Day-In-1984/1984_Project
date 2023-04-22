using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class JumpState : IState
{
    private PlayerStateController stateController;
    private PlayerMoveTracker moveTracker;
    private Rigidbody2D rigidbody;

    private readonly float jumpForce = 13f;
    private float keyHorizontal;
    private float keyVertical;
    private bool keySpace;


    public JumpState(PlayerStateController playerStateController, PlayerMoveTracker playerMoveTracker, Rigidbody2D rigidbody)
    {
        this.stateController = playerStateController;
        this.moveTracker = playerMoveTracker;
        this.rigidbody = rigidbody;
    }

    public void Enter()
    {
        Debug.Log("Jump Enter()");
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);        
    }

    public void Execute()
    {
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log("Jump Execute()");
    }

    public void FixedExecute() 
    {
         
        // 캐릭터가 점프할 때 수행할 작업
        if (rigidbody.velocity.y == 0)
        {
            stateController.ChangeState(PLAYER_STATE.IDLE);
        }

        if (Input.GetButton("Horizontal"))
        {
            stateController.ChangeState(PLAYER_STATE.RUN);
        }
    }

    public void Exit()
    {
        Debug.Log("Jump Exit()");
    }


}
