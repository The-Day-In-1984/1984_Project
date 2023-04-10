using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMission : MonoBehaviour, IMission, IPointerClickHandler
{
    [Header("Target")]
    [SerializeField] private int successValue = 5;

    private MissionController _missionController;
    private CountLogic _countLogic;
    
    public bool IsCompleted { get; private set; }
    
    private void Awake()
    {
        _missionController = GetComponentInParent<MissionController>();
        _missionController.AddMission(this);
        
        _countLogic = new CountLogic(successValue);
        _countLogic.OnCountMax += OnMissionComplete;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsCompleted)
            return;

        _countLogic.AddCount(1);
    }
}
