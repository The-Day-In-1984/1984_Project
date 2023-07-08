using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    protected readonly List<IMission> _missions = new List<IMission>();
    private UIMissionView _view;

    public bool IsComplete { get; private set; } = false;

    private void Awake()
    {
        _view = GetComponentInParent<UIMissionView>();
    }

    public void AddMission(IMission mission)
    {
        _missions.Add(mission);
        mission.MissionCompleted += CheckMissionComplete;
        mission.MissionFailed += CheckMissionFail;
    }

    protected virtual void CheckMissionComplete()
    {
       
    }
    
    protected virtual void CheckMissionFail()
    {
        
    }
    
    protected async void MissionComplete()
    {
        GameManager.Data.SetReliability(10);
        IsComplete = true;
        
        SoundManager.instance.PlayEffect("Mission_Clear");

        await Task.Delay(2000);

        _view.Hide();
    }
    
    protected async void MissionFail()
    {
        GameManager.Data.SetReliability(-5);
        IsComplete = true;
        
        SoundManager.instance.PlayEffect("Mission_Fail");
        
        await Task.Delay(2000);
        
        _view.Hide();
    }

    public async Task MissionComplete(Action callBack)
    {
        while (!IsComplete)
        {
            await Task.Yield();
        }
        
        callBack?.Invoke();
    }
} 
