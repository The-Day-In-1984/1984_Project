using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragMission : MonoBehaviour, IMission, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [Header("Target")] 
    [SerializeField] private Transform target;
    [SerializeField] private float successDistance = 20f;
    
    private MissionController _missionController;
    private DistanceLogic _distanceLogic;
    
    [SerializeField] private UnityEvent onDragStart;
    [SerializeField] private UnityEvent onDragEnd;
    
    public bool IsCompleted { get; private set; }
    
    private void Awake()
    {
        _missionController = GetComponentInParent<MissionController>();
        _missionController.AddMission(this);
    }

    public virtual void OnMissionStart()
    {
        IsCompleted = false;
        
        _distanceLogic = new DistanceLogic(this.transform, target, successDistance);
        _distanceLogic.OnSuccess += OnMissionComplete;
    }

    public virtual void OnMissionComplete()
    {
        _distanceLogic.OnSuccess -= OnMissionComplete;
        
        IsCompleted = true;
        _missionController.CheckAllMissionsComplete();
    }
    
    public virtual void OnDrag(PointerEventData eventData)
    {
        if (IsCompleted)
            return;
        
        SetTransformPosition(eventData.position);

        _distanceLogic.DistanceCalculation();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        onDragStart?.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        onDragEnd?.Invoke();
    }
    
    private void SetTransformPosition(Vector3 position)
    {
        transform.position = position;
    }
}
