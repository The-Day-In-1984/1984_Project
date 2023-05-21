using System;
using UnityEngine;

public class BaseMission : MonoBehaviour, IMission
{
    private MissionController _missionController;
    private bool _isCompleted;
    
    public event Action MissionCompleted;
    public bool IsCompleted
    {
        get { return _isCompleted; }
        private set
        {
            _isCompleted = value;
            if (_isCompleted)
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

    public virtual void OnMissionStart()
    {
        IsCompleted = false;
    }

    public virtual void OnMissionComplete()
    {
        IsCompleted = true;
    }
}
