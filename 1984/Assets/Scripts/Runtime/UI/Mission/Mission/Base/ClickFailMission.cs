using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Enums;

public class ClickFailMission : BaseMission, IPointerClickHandler
{
    [Header("Target")]
    [SerializeField] private int successValue = 5;
    
    private CountLogic _countLogic;

    protected override void Awake()
    {
        base.Awake();
        
        _countLogic = new CountLogic(successValue);
        _countLogic.onCountMax += OnMissionFail;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        MissionLogic();
    }
    
    private void MissionLogic()
    {
        if (IsMissionState == MissionState.InProgress)
        {
            _countLogic.AddCount(1);
        }
    }
}
