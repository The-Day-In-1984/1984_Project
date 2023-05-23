using UnityEngine;
using Enums;

public class TriggerMission : BaseMission
{
    [Header("Target")] 
    [SerializeField] protected int successValue = 1;
    
    protected CountLogic _timeLogic;
    
    protected override void Awake()
    {
        base.Awake();
        
        _timeLogic = new CountLogic(successValue);
        _timeLogic.onCountMax += OnMissionComplete;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        MissionLogic(col);
    }

    private void MissionLogic(Collider2D col)
    {
        if (IsMissionState == MissionState.InProgress)
        {
            if (col.CompareTag("Target"))
            {
                _timeLogic.AddCount(1);
            }
        }
    }
}
