using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class PlayerStateController : MonoBehaviour
{
    private PLAYER_STATE currentPlayerState;
    private IState currentState;
    private Rigidbody2D rigidbody2D;
    public PlayerMoveTracker playerMoveTracker;

    private void Awake()
    {  
        // 기본 상태를 Idle로 설정
        currentPlayerState = PLAYER_STATE.IDLE;
        playerMoveTracker = GetComponent<PlayerMoveTracker>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentState = new IdleState(this, playerMoveTracker, rigidbody2D);

    }

    private void Start()
    {
        currentState.Enter();
    }

    private void Update()
    {
        currentState.Execute();
    }

    private void FixedUpdate()
    {
        currentState.FixedExecute();
    }

    public void ChangeState(PLAYER_STATE newState)
    {
        // 상태 변경
        if (currentState != null)
        {
            currentState.Exit();
        }

        switch (newState)
        {
            case PLAYER_STATE.IDLE:
                currentState = new IdleState(this, playerMoveTracker, rigidbody2D);
                break;

            case PLAYER_STATE.RUN:
                currentState = new RunState(this, playerMoveTracker, rigidbody2D);
                break;

            case PLAYER_STATE.JUMP:
                currentState = new JumpState(this, playerMoveTracker, rigidbody2D);
                break;

            case PLAYER_STATE.CLIMB:
                currentState = new ClimbState(this, playerMoveTracker, rigidbody2D);
                break;
        }
        currentPlayerState = newState;
        currentState.Enter();
    }
}
