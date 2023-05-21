using System;

public interface IMission
{
    event  Action MissionCompleted;
    bool IsCompleted { get; }
    void OnMissionStart();
    void OnMissionComplete();
}
