using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerStateController stateController;

    public IState previousState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stateController = GetComponent<PlayerStateController>();

        previousState = stateController.currentState;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(previousState.ToString());
        if(previousState != stateController.currentState)
        {
            UpdateAnimation();
        }
    }

    private void UpdateAnimation()
    {
        switch (stateController.currentState)
        {
            case IdleState:
                PlayIdleAnimation();
                break;
            case RunState:
                PlayRunAnimation();
                break;
        }

        previousState = stateController.currentState; // 상태 업데이트
    }

    private void PlayIdleAnimation()
    {
        animator.Play("Idle");
    }
    private void PlayRunAnimation()
    {
        animator.Play("Run");
    }
}
