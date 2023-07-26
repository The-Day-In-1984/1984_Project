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
    [SerializeField] private Slider contributionsSlider;

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
        playerData.Contributions.onChange += UpdateContributions;
        playerData.Timer.onChange += UpdateTimerUI;
    }
    
    private void OnDisable()
    {
        playerData.Reliability.onChange -= UpdateReliabilityUI;
        playerData.Contributions.onChange -= UpdateContributions;
        playerData.Timer.onChange -= UpdateTimerUI;
    }

    private void UpdateReliabilityUI(int value)
    {
        reliabilitySlider.value = value;
    }

    private void UpdateContributions(int value)
    {
        contributionsSlider.value = value;
    }

    private void UpdateTimerUI(float timer)
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = $"{minutes:D2}:{seconds:D2}";
    }
}