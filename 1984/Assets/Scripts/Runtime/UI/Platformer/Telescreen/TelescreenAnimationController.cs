using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class TelescreenAnimationController : MonoBehaviour
{
    private Animator animator;
    private Telescreen telescreen;
    private GameObject bigBrother;

    private ITelescreen previousState; // 이전 상태 저장

    private void Start()
    {
        animator = GetComponent<Animator>();
        telescreen = GetComponent<Telescreen>();
        bigBrother = GameObject.Find("BigBrother");

        previousState = telescreen.currentState; // 초기 상태 설정
        UpdateAnimation();
    }

    private void Update()
    {
        if (previousState != telescreen.currentState)
        {
            UpdateAnimation();
        }
    }

    private void UpdateAnimation()
    {
        switch (telescreen.currentState)
        {
            case TeleScreen.ReadyState:
                PlayReadyAnimation();
                break;
            case TeleScreen.OnState:
                PlayOnAnimation();
                break;
            case TeleScreen.OffState:
                PlayOffAnimation();
                break;
        }

        previousState = telescreen.currentState; // 상태 업데이트
    }

    private void PlayReadyAnimation()
    {
        animator.Play(nameof(TeleScreen.ReadyState));
        //Debug.Log("ReadyAnimation");
    }

    private void PlayOnAnimation()
    {
        animator.Play(nameof(TeleScreen.OnState));
        //bigBrother.SetActive(true);
    }

    private void PlayOffAnimation()
    {
        animator.Play(nameof(TeleScreen.OffState));
        //bigBrother.SetActive(false);
    }
}