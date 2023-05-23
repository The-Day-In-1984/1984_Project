using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTimeMission : TimeMission
{
    [SerializeField] private UnityEvent onCompleted;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Target"))
        {
            StartCount();
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Target"))
        {
            StopCount();
        }
    }
    
    public override void OnMissionComplete()
    {
        base.OnMissionComplete();
        onCompleted?.Invoke();
    }
}
