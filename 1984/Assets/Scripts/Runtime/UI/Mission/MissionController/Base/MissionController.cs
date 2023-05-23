using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    protected readonly List<IMission> _missions = new List<IMission>();
    private UiMissionView _view;

    private void Awake()
    {
        _view = GetComponentInParent<UiMissionView>();
    }

    public void AddMission(IMission mission)
    {
        _missions.Add(mission);
        mission.MissionCompleted += CheckMissionComplete;
        mission.MissionFailed += CheckMissionFail;
    }

    protected virtual void CheckMissionComplete()
    {
        Debug.Log("성공 한번 체크");
    }
    
    protected virtual void CheckMissionFail()
    {
        Debug.Log("실패 한번 체크");
    }

    
    protected void MissionComplete()
    {
        // 미션 성공하면 로직
        // 화면 사라지거나 애니메이션 등등처리
        GameManager.Data.SetReliability(10);
        _view.Hide(); // temp 연출 넣기
        //_view.Test();
        
        Debug.Log("성공");
    }
    
    protected void MissionFail()
    {
        // 미션 실패하면 로직
        // 화면 사라지거나 애니메이션 등등처리
        GameManager.Data.SetReliability(-10);
        _view.Hide();
        
        Debug.Log("실패");
    }
} 
