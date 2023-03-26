using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMission : MonoBehaviour, IMission, IDragHandler, IEndDragHandler
{
    [Header("MissionController")]
    [SerializeField] private MissionController missionController;

    [Header("Target Location")] 
    [SerializeField] private Transform target;
    [SerializeField] private float successDistance = 20f;
    
    private void Awake()
    {
        missionController.AddMission(this);
    }
    
    public bool IsCompleted { get; private set; }
    
    public void OnMissionStart()
    {
        IsCompleted = false;
    }

    public void OnMissionComplete()
    {
        IsCompleted = true;
        missionController.CheckAllMissionsComplete();
    }


    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = eventData.position;
        
        if (Vector3.Distance(transform.position, target.position) <= successDistance)
        {
            OnMissionComplete();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // temp
    }
}
