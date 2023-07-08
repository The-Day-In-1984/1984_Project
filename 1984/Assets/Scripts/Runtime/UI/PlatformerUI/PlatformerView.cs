using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlatformerView : UIView 
{
    [Header("Player Data")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Slider reliabilitySlider;
    [SerializeField] private Color reliabilityColorLow;
    [SerializeField] private Color reliabilityColorHigh;

    [Header("Timer")]
    [SerializeField] private TextMeshProUGUI timerText;
    
    private Image _sliderImage;
    private void Awake()
    {
        _sliderImage = reliabilitySlider.fillRect.GetComponent<Image>();
    }

    private void OnEnable()
    {
        playerData.Reliability.onChange += UpdateReliabilityUI;
        playerData.Timer.onChange += UpdateTimerUI;
    }
    
    private void OnDisable()
    {
        playerData.Reliability.onChange -= UpdateReliabilityUI;
        playerData.Timer.onChange -= UpdateTimerUI;
    }

    private void UpdateReliabilityUI(int hp)
    {
        reliabilitySlider.value = hp;
        //_sliderImage.color = Color.Lerp(reliabilityColorLow, reliabilityColorHigh, reliabilitySlider.normalizedValue);
    }
    
    private void UpdateTimerUI(float timer)
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }
}