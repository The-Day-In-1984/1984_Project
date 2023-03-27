public interface IMission
{
    bool IsCompleted { get; }
    void OnMissionStart();
    void OnMissionComplete();
}
