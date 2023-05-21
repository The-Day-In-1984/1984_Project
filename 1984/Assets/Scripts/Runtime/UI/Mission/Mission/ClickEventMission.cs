using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickEventMission : ClickMission
{
    [SerializeField] private UnityEvent onCompleted;
    
    public override void OnMissionStart()
    {
        base.OnMissionStart();
    }

    public override void OnMissionComplete()
    {
        base.OnMissionComplete();
        
        onCompleted?.Invoke();
    }
}
