using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
  
public class PlayerStateController : MonoBehaviour
{
    public IState currentState;
    private Rigidbody2D rigidbody2D;
    [HideInInspector] public PLAYER_STATE currentPlayerState;
    [HideInInspector] public Transform transform;
    [HideInInspector] public PlayerMoveTracker playerMoveTracker;

    private readonly Dictionary<PLAYER_STATE, IState> stateDictionary = new Dictionary<PLAYER_STATE, IState>();


    private void Awake()
    {

        // 기본 상태를 Idle로 설정
        currentPlayerState = PLAYER_STATE.IDLE;
        playerMoveTracker = GetComponent<PlayerMoveTracker>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentState = new IdleState(this, playerMoveTracker, rigidbody2D);

        stateDictionary.Add(PLAYER_STATE.IDLE, new IdleState(this, playerMoveTracker, rigidbody2D));
        stateDictionary.Add(PLAYER_STATE.RUN, new RunState(this, playerMoveTracker, rigidbody2D));

        transform = this.gameObject.transform;
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
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = stateDictionary[newState];
        currentPlayerState = newState;
        currentState.Enter();
    }
}
