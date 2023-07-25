using System;
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
    }

    private void Update()
    {
        ControlVolume(masterVolumeSlider, "Master");
        ControlVolume(bgmVolumeSlider, "BGM");
        ControlVolume(effectVolumeSlider, "Effect");
    }

    private void ControlVolume(Slider slider, string soundType)
    {
        float volume = slider.value;

        if (volume <= -30f) SoundManager.instance.SetVolume(soundType,-80);
        else SoundManager.instance.SetVolume(soundType,volume);
    }
}