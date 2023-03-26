using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMission
{
    bool IsCompleted { get; }
    void OnMissionStart();
    void OnMissionComplete();
}
