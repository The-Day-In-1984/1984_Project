using UnityEngine;
using UnityEngine.EventSystems;

public class ClickMission : MonoBehaviour, IMission, IPointerClickHandler
{
    [Header("MissionController")]
    [SerializeField] private MissionController missionController;

    [Header("Target Value")]
    [SerializeField] private int successValue = 5;

    private int _clickCount;
    
    public bool IsCompleted { get; private set; }
    
    private void Awake()
    {
        missionController.AddMission(this);
    }

    public void OnMissionStart()
    {
        IsCompleted = false;
        _clickCount = 0;
    }

    public void OnMissionComplete()
    {
        IsCompleted = true;
        missionController.CheckAllMissionsComplete();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _clickCount++;

        if (_clickCount >= successValue)
        {
            OnMissionComplete();
        }
    }
}
