using System;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class OrderNotFailMissionController : MissionController
{
    private int _currentMissionIndex = 0;
    private void Start()
    {
        AllMissionReady();
        
        //_missions.Reverse();

        _missions[_currentMissionIndex].OnMissionInProgress();
    }
    
    private void AllMissionReady()
    {
        foreach (var mission in _missions)
        {
            mission.OnMissionReady();
        }
    }

    protected override void CheckMissionComplete()
    {
        base.CheckMissionComplete();

        if (_currentMissionIndex < _missions.Count - 1)
        {
            _missions[++_currentMissionIndex].OnMissionInProgress();
        }
        else
        {
            MissionComplete(); 
        }
    }
}
