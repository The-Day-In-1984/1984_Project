﻿using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class NoOrderFailMissionController : MissionController
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
            if (_missions[i].IsIgnore)
            {
                continue;
            }

            if (_missions[i].IsMissionState != MissionState.Complete)
            {
                return;
            }
        }

        MissionComplete();
    }
    
    protected override void CheckMissionFail()
    {
        base.CheckMissionFail();
        
        MissionFail();
    }
}
