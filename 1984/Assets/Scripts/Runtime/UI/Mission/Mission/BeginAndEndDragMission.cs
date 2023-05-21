using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BeginAndEndDragMission : DragMission, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private UnityEvent onBeginDrag;
    [SerializeField] private UnityEvent onEndDrag;
    
    private Vector3 _startPosition;

    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnMissionStart()
    {
        base.OnMissionStart();
        
        _startPosition = transform.position;
    }

    public override void OnMissionComplete()
    {
        base.OnMissionComplete();
    }
    
    public virtual void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        onBeginDrag?.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        PositionUpdate(_startPosition);
        
        onEndDrag?.Invoke();
    }
}
