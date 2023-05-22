using System;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    protected readonly List<IMission> _missions = new List<IMission>();

    public void AddMission(IMission mission)
    {
        _missions.Add(mission);
        mission.MissionCompleted += CheckMissionComplete;
    }

    protected virtual void CheckMissionComplete()
    {
        Debug.Log("Check");
    }
    
    protected void MissionComplete()
    {
        // 미션 성공하면 로직
        // 화면 사라지거나 애니메이션 등등처리
        Debug.Log("성공");
    }
    
    protected void MissionFail()
    {
        // 미션 실패하면 로직
        // 화면 사라지거나 애니메이션 등등처리
        Debug.Log("실패");
    }
} 
