using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        if (IsCompleted)
        {
            return;
        }

        if (col.CompareTag("Target"))
        {
            _timeLogic.AddCount(1);
        }
    }
}
