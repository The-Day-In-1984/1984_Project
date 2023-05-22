using System;
using Enums;

public interface IMission
{
    event  Action MissionCompleted;
    MissionState IsMissionState { get; }
    void OnMissionInProgress();
    void OnMissionComplete();
    void OnMissionFail();
    void OnMissionReady();
}
