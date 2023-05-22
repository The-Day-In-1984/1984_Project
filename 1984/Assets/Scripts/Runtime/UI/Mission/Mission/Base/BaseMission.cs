using System;
using UnityEngine;
using Enums;

public class BaseMission : MonoBehaviour, IMission
{
    private MissionController _missionController;
    private MissionState _isMissionState;
    
    public event Action MissionCompleted;
    public MissionState IsMissionState
    {
        get { return _isMissionState; }
        private set
        {
            _isMissionState = value;
            if (_isMissionState == MissionState.Complete)
            {
                MissionCompleted?.Invoke();
            }
        }
    }

    protected virtual void Awake()
    {
        _missionController = GetComponentInParent<MissionController>();
        _missionController.AddMission(this);
    }
    
    public virtual void OnMissionReady()
    {
        IsMissionState = MissionState.Ready;
    }
    public virtual void OnMissionInProgress()
    {
        IsMissionState = MissionState.InProgress;
    }

    public virtual void OnMissionComplete()
    {
        IsMissionState = MissionState.Complete;
    }
    
    public virtual void OnMissionFail()
    {
        IsMissionState = MissionState.Fail;
    }
    

}
