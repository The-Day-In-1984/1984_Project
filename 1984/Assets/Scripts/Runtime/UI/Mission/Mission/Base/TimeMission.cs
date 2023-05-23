using System;
using System.Collections;
using UnityEngine;
using Enums;

public class TimeMission : BaseMission
{
    [Header("Target")]
    [SerializeField] private int successValue = 5;
    
    private CountLogic _timeLogic;

    protected override void Awake()
    {
        base.Awake();
        
        _timeLogic = new CountLogic(successValue);
        _timeLogic.onCountMax += OnMissionComplete;
    }
    
    private IEnumerator StartCountCoroutine()
    {
        while (IsMissionState == MissionState.InProgress)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            _timeLogic.AddCount(Time.deltaTime);
        }
    }
    
    public void StartCount()
    {
        StartCoroutine(StartCountCoroutine());
    }
    
    public void StopCount()
    {
        StopAllCoroutines();
    }
}
