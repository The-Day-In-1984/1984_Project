using System;
using Enums;
using UnityEngine;

public interface IMission
{
    public int MissionOrder { get; set; }
    public bool IsIgnore { get; set; }
    event Action MissionCompleted;
    event Action MissionFailed;
    MissionState IsMissionState { get; }
    void OnMissionInProgress();
    void OnMissionComplete();
    void OnMissionFail();
    void OnMissionReady();
}
