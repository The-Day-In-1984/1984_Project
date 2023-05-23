using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BeginAndEndDragMission : DragMission, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private UnityEvent onBeginDrag;
    [SerializeField] private UnityEvent onEndDrag;
    
    private Vector3 _startPosition;

    public override void OnMissionInProgress()
    {
        base.OnMissionInProgress();
        
        _startPosition = transform.position;
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
