using UnityEngine;
using UnityEngine.EventSystems;

public class DragMission : MonoBehaviour, IMission, IDragHandler
{
    [Header("Target")] 
    [SerializeField] private Transform target;
    [SerializeField] private float successDistance = 20f;
    
    private MissionController _missionController;
    private DistanceLogic _distanceLogic;
    
    public bool IsCompleted { get; private set; }
    
    private void Awake()
    {
        _missionController = GetComponentInParent<MissionController>();
        _missionController.AddMission(this);
        
        _distanceLogic = new DistanceLogic(this.transform, target, successDistance);
        _distanceLogic.OnSuccess += OnMissionComplete;
    }

    public void OnMissionStart()
    {
        IsCompleted = false;
    }

    public void OnMissionComplete()
    {
        IsCompleted = true;
        _missionController.CheckAllMissionsComplete();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (IsCompleted)
            return;

        gameObject.transform.position = eventData.position;

        _distanceLogic.DistanceCalculation();
    }
}
