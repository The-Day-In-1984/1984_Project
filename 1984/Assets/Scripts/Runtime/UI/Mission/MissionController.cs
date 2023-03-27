using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private readonly List<IMission> _missions = new List<IMission>();

    public void AddMission(IMission mission)
    {
        _missions.Add(mission);
    }

    private void Start()
    {
        foreach (var mission in _missions)
        {
            mission.OnMissionStart();
        }
    }

    public bool CheckAllMissionsComplete()
    {
        foreach (var mission in _missions)
        {
            if (!mission.IsCompleted)
            {
                return false;
            }
        }
        
        Debug.Log("성공");
        
        return true;
    }
}
