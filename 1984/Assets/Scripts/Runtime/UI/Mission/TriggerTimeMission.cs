using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimeMission : MonoBehaviour, IMission
{ 
    [Header("MissionController")]
    [SerializeField] private MissionController missionController;

    [Header("Target")]
    [SerializeField] private Transform target;
    [SerializeField] private float successValue = 2f;
    [SerializeField] private float successDistance = 10f;

    private float _curTime;

    public bool IsCompleted { get; private set; }
    
    private void Awake()
    {
        missionController.AddMission(this);
    }

    public void OnMissionStart()
    {
        IsCompleted = false;
    }

    public void OnMissionComplete()
    {
        IsCompleted = true;
        missionController.CheckAllMissionsComplete();
    }

    private void Update()
    {
        if (IsCompleted)
            return;

        var distance = Vector3.Distance(transform.position, target.position);
        
        if (distance <= successDistance)
        {
            _curTime += Time.deltaTime;
            if (_curTime >= successValue)
            {
                OnMissionComplete();
            }
        }
        else
        {
            _curTime = 0;
        }
    }
}
