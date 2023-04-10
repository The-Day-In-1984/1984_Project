using System;

public class TimeLogic
{
    public Action OnTimeChanged;
    public Action OnTimeMax;
    
    private float _time;
    private readonly float _maxTime;
    
    public TimeLogic(float maxTime, float time = 0)
    {
        _maxTime = maxTime;
        _time = time;
    }
    
    public void AddTime(float time)
    {
        _time += time;
        OnTimeChanged?.Invoke();
        
        if (_time >= _maxTime)
        {
            OnTimeMax?.Invoke();
        }
    }
}
