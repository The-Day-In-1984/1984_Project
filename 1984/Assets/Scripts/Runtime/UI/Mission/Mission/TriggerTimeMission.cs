using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTimeMission : TimeMission
{
    [SerializeField] private UnityEvent onCompleted;
    [SerializeField] private UnityEvent OnProgress;
    [SerializeField] private UnityEvent OnReset;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Target"))
        {
            StartCount();
            OnProgress?.Invoke();
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Target"))
        {
            StopCount();
            OnReset?.Invoke();
        }
    }
    
    public override void OnMissionComplete()
    {
        base.OnMissionComplete();
        onCompleted?.Invoke();
    }
}
