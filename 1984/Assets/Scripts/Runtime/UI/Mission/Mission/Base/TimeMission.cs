using System;
using System.Collections;
using UnityEngine;

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
    public override void OnMissionStart()
    {
        base.OnMissionStart();
    }

    public override void OnMissionComplete()
    {
        base.OnMissionComplete();
    }
    
    private IEnumerator StartCountCoroutine()
    {
        while (!IsCompleted)
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
