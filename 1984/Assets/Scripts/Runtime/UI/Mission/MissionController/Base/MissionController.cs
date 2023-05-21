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

    private void Start()
    {
        foreach (var mission in _missions)
        {
            mission.OnMissionStart();
        }
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
    
    
    // public bool CheckAllMissionsComplete()
    // {
    //     if (isOrderMissions)
    //     {
    //         for (var i = 0; i < _missions.Count; i++)
    //         {
    //             if (!_missions[i].IsCompleted)
    //             {
    //                 return false;
    //             }
    //         }
    //         
    //         MissionComplete();
    //         
    //         return true;
    //     }
    //
    //     foreach (var mission in _missions)
    //     {
    //         if (!mission.IsCompleted)
    //         {
    //             return false;
    //         }
    //     }
    //
    //     MissionComplete();
    //     
    //     return true;
    // }
    
    // private void MissionComplete(IMission mission)
    // {
    //     if (isOrderMissions)
    //     {
    //         var index = _missions.IndexOf(mission);
    //         if (index + 1 < _missions.Count)
    //         {
    //             _missions[index + 1].OnMissionStart();
    //         }
    //     }
    // }
} 
