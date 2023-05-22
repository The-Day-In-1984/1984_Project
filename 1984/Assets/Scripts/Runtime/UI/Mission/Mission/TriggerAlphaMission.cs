using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerAlphaMission : TriggerMission
{
    [SerializeField] private bool isDescending = true;
    private Image _image;
    
    private int _currentValue = 1;
    
    protected override void Awake()
    {
        base.Awake();

        _image = GetComponent<Image>();
        
        _timeLogic.onCountChanged += AlphaDown;
    }
    
    private void AlphaDown()
    {
        if (_currentValue <= successValue)
        {
            float startAlpha;
            float endAlpha;

            float t = Mathf.Clamp01(_currentValue / (float)successValue);
            
            if (isDescending)
            {
                startAlpha = 1f;
                endAlpha = 0f;
            }
            else
            {
                startAlpha = 0f;
                endAlpha = 1f;
            }
            
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, t);
            
            Color newColor = _image.color;
            newColor.a = newAlpha;
            _image.color = newColor;

            _currentValue++;
        }
    }
}
