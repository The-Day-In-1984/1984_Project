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

    // 미션 단계별 성공
    protected virtual void CheckMissionComplete()
    {
       
    }
    
    // 단계별 실패
    protected virtual void CheckMissionFail()
    {
        
    }
    
    protected async void MissionComplete()
    {
        GameManager.Data.IsMission = false;
        GameManager.Data.SetReliability(10);
        IsComplete = true;
        
        SoundManager.instance.PlayEffect("Mission_Clear");

        await Task.Delay(2000);

        _view.Hide();
    }
    
    protected async void MissionFail()
    {
        GameManager.Data.IsMission = false;
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
