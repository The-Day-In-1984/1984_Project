using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private PlayerStateController characterStateManager;
    private PlayerMoveTracker playerMoveTracking;
    private bool isClimbing=false;
    //public bool isNearLadder;
    [HideInInspector] public Ladder ladder;


    private void Start()
    {
        characterStateManager = GetComponent<PlayerStateController>();
        playerMoveTracking = GetComponent<PlayerMoveTracker>();
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") && !isClimbing)
        {
            characterStateManager.ChangeState(PLAYER_STATE.RUN);
        }
        else if( !isClimbing )
        {
            characterStateManager.ChangeState(PLAYER_STATE.IDLE);
        }

        if (Input.GetKey(KeyCode.Space) && !isClimbing)
        {
            characterStateManager.ChangeState(PLAYER_STATE.JUMP);
        }

        if (Input.GetButton("Vertical") && playerMoveTracking.isNearLadder && !isClimbing)
        {
            isClimbing = true;
            characterStateManager.ChangeState(PLAYER_STATE.CLIMB);
        }
    }

}
