using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class NoOrderNotFailMissionController : MissionController
{
    private void Start()
    {
        AllMissionInprogress();
    }
    
    private void AllMissionInprogress()
    {
        foreach (var mission in _missions)
        {
            mission.OnMissionInProgress();
        }
    }

    protected override void CheckMissionComplete()
    {
        base.CheckMissionComplete();
        
        for (var i = 0; i < _missions.Count; i++)
        {
            if (_missions[i].IsMissionState != MissionState.Complete)
            {
                return;
            }
        }
            
        MissionComplete();
    }
}
