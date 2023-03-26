using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private List<IMission> missions = new List<IMission>();

    public void AddMission(IMission mission)
    {
        missions.Add(mission);
    }

    private void Start()
    {
        foreach (var mission in missions)
        {
            mission.OnMissionStart();
        }
    }

    public bool CheckAllMissionsComplete()
    {
        foreach (var mission in missions)
        {
            if (!mission.IsCompleted)
            {
                return false;
            }
        }
        
        Debug.Log("성공");
        
        return true;
    }
}
