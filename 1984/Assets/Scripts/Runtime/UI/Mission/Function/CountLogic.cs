using System;
using UnityEngine;

public class CountLogic
{
    public Action onCountChanged;
    public Action onCountMax;
    
    private float _count;
    private readonly float _maxCount;
    
    public CountLogic(float maxCount, float count = 0)
    {
        _maxCount = maxCount;
        _count = count;
    }
    
    public void AddCount(float count)
    {
        Debug.Log(_count);
        _count += count;
        onCountChanged?.Invoke();
        
        if (_count >= _maxCount)
        {
            onCountMax?.Invoke();
        }
    }
}
