using UnityEngine;
using UnityEngine.EventSystems;

public class DragMission : MonoBehaviour, IMission, IDragHandler, IEndDragHandler
{
    [Header("MissionController")]
    [SerializeField] private MissionController missionController;

    [Header("Target Location")] 
    [SerializeField] private Transform target;
    [SerializeField] private float successDistance = 20f;
    
    public bool IsCompleted { get; private set; }
    
    private void Awake()
    {
        missionController.AddMission(this);
    }

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

        var distance = Vector3.Distance(transform.position, target.position);
        
        if (distance <= successDistance)
        {
            OnMissionComplete();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // temp
    }
}
