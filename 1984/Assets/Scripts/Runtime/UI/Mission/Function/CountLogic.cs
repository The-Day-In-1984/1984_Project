using System;

public class CountLogic
{
    public Action OnCountChanged;
    public Action OnCountMax;
    
    private float _count;
    private readonly float _maxCount;
    
    public CountLogic(float maxCount, float count = 0)
    {
        _maxCount = maxCount;
        _count = count;
    }
    
    public void AddCount(int count)
    {
        _count += count;
        OnCountChanged?.Invoke();
        
        if (_count >= _maxCount)
        {
            OnCountMax?.Invoke();
        }
    }
}
