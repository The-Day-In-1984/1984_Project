using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMission : BaseMission, IPointerClickHandler
{
    [Header("Target")]
    [SerializeField] private int successValue = 5;
    
    private CountLogic _countLogic;

    protected override void Awake()
    {
        base.Awake();
        
        _countLogic = new CountLogic(successValue);
        _countLogic.onCountMax += OnMissionComplete;
    }

    public override void OnMissionStart()
    {
        base.OnMissionStart();
    }

    public override void OnMissionComplete()
    {
        base.OnMissionComplete();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsCompleted)
            return;

        _countLogic.AddCount(1);
    }
}
