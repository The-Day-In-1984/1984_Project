using UnityEngine;
using System;

public class DistanceLogic
{
    public Action OnSuccess;
    
    private readonly Transform _transform;
    private readonly Transform _target;
    private readonly float _successDistance;
    
    public DistanceLogic(Transform transform,Transform target, float successDistance)
    {
        _transform = transform;
        _target = target;
        _successDistance = successDistance;
    }
    
    public bool DistanceCalculation()
    {
        float distance = Vector3.Distance(_transform.position, _target.position);
        
        if (distance <= _successDistance)
        {
            OnSuccess?.Invoke();
            return true;
        }

        return false;
    }
}