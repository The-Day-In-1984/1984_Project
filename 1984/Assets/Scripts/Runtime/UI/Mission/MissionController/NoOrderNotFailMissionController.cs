using System;
using System.Collections.Generic;
using UnityEngine;

public class NoOrderNotFailMissionController : MissionController
{
    protected override void CheckMissionComplete()
    {
        base.CheckMissionComplete();
        
        for (var i = 0; i < _missions.Count; i++)
        {
            if (!_missions[i].IsCompleted)
            {
                return;
            }
        }
            
        MissionComplete();
    }
}
