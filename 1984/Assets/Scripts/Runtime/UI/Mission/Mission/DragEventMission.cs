
using UnityEngine.Events;

public class DragEventMission : DragMission
{
    public UnityEvent onCompleted;

    protected override void Awake()
    {
        base.Awake();

        MissionCompleted += onCompleted.Invoke;
    }
}
