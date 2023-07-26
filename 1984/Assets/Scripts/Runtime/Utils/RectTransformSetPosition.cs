using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransformSetPosition : MonoBehaviour
{
    [SerializeField] private RectTransform targetPosition;
    
    private RectTransform _rectTransform;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }
    
    public void SetPosition()
    {
        _rectTransform.position = targetPosition.position;
    }
}
