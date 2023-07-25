using System;
using Enums;
using UnityEngine;
using UnityEngine.UI;

public class SettingViewController : MonoBehaviour
{
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider bgmVolumeSlider;
    [SerializeField] private Slider effectVolumeSlider;
    [SerializeField] private Slider textSpeedSlider;

    private void Start()
    {
        masterVolumeSlider.value = SoundManager.instance.GetVolume("Master");
        bgmVolumeSlider.value = SoundManager.instance.GetVolume("BGM");
        effectVolumeSlider.value = SoundManager.instance.GetVolume("Effect");
        textSpeedSlider.value = GameManager.UI.TextSpeed;
    }

    private void Update()
    {
        ControlVolume(masterVolumeSlider, "Master");
        ControlVolume(bgmVolumeSlider, "BGM");
        ControlVolume(effectVolumeSlider, "Effect");
        ControlTextSpeed(textSpeedSlider);
    }

    private void ControlVolume(Slider slider, string soundType)
    {
        float volume = slider.value;

        if (volume <= -30f) SoundManager.instance.SetVolume(soundType,-80);
        else SoundManager.instance.SetVolume(soundType,volume);
    }
    private void ControlTextSpeed(Slider slider)
    {
        float speed = slider.value;
        GameManager.UI.TextSpeed = speed;
    }
    public void OnExitButtonClick()
    {
        GameManager.UI.ChangeState(GameState.Ttitle);
    }
}