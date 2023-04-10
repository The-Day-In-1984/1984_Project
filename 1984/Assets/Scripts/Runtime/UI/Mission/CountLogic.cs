using System;
using UnityEngine;

public class Counter
{
    public Action OnCountChanged;
    public Action OnCountMax;
    
    private int _count;
    private readonly int _maxCount;
    
    public Counter(int maxCount, int count = 0)
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
