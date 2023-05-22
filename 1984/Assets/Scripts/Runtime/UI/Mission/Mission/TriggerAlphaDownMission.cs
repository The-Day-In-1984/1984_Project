using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerAlphaDownMission : TriggerMission
{
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
            float startAlpha = _image.color.a;
            float endAlpha = 0f;

            float t = Mathf.Clamp01(_currentValue / (float)successValue); // 비율 계산

            // 알파값 보간 계산
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, t);

            // 이미지의 알파값 업데이트
            Color newColor = _image.color;
            newColor.a = newAlpha;
            _image.color = newColor;

            _currentValue++;
        }
    }
}
