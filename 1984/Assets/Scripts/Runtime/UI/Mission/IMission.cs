using System;
using Enums;

public interface IMission
{
    event Action MissionCompleted;
    event Action MissionFailed;
    MissionState IsMissionState { get; }
    void OnMissionInProgress();
    void OnMissionComplete();
    void OnMissionFail();
    void OnMissionReady();
}
