using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragMission : BaseMission, IDragHandler
{
    [Header("Target")] 
    [SerializeField] private Transform target;
    [SerializeField] private float successDistance = 20f;
    
    private DistanceLogic _distanceLogic;

    protected override void Awake()
    {
        base.Awake();
        
        _distanceLogic = new DistanceLogic(this.transform, target, successDistance);
        _distanceLogic.onSuccess += OnMissionComplete;
    }

    public override void OnMissionStart()
    {
        base.OnMissionStart();
    }

    public override void OnMissionComplete()
    {
        base.OnMissionComplete();
    }
    
    public virtual void OnDrag(PointerEventData eventData)
    {
        PositionUpdate(eventData.position);
        
        if(IsCompleted)
            return;
        _distanceLogic.DistanceCalculation();
    }
    
    public void PositionUpdate(Vector2 position)
    {
        transform.position = position;
    }
}
