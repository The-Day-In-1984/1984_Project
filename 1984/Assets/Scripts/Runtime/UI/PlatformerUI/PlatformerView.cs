using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlatformerView : UIView 
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Slider reliabilitySlider;
    [SerializeField] private Color reliabilityColorLow;
    [SerializeField] private Color reliabilityColorHigh;

    private Image _sliderImage;
    private void Awake()
    {
        _sliderImage = reliabilitySlider.fillRect.GetComponentInChildren<Image>();
    }

    private void OnEnable()
    {
        playerData.Reliability.onChange += UpdateReliabilityUI;
    }
    
    private void OnDisable()
    {
        playerData.Reliability.onChange -= UpdateReliabilityUI;
    }

    private void UpdateReliabilityUI(int hp)
    {
        reliabilitySlider.value = hp;
        //_sliderImage.color = Color.Lerp(reliabilityColorLow, reliabilityColorHigh, reliabilitySlider.normalizedValue);
    }
}