using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using YG;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider renderScaleSlider;
    [SerializeField] private Toggle anitAliasingToggle;


    [SerializeField] private TextMeshProUGUI volumeValueLabel;
    [SerializeField] private TextMeshProUGUI renderScaleLabel;



    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private UniversalRenderPipelineAsset urpAsset;

    private void OnEnable()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        renderScaleSlider.onValueChanged.AddListener(OnRenderScaleSliderChanged);
        anitAliasingToggle.onValueChanged.AddListener(OnAntiAliasingToggleChanged);
    }

    private void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveListener(OnVolumeSliderChanged);
        renderScaleSlider.onValueChanged.RemoveListener(OnRenderScaleSliderChanged);
    }



    private void Start()
    {
        float soundVolume;

        masterMixer.GetFloat("VolumeMixer", out soundVolume);
        soundVolume = MathF.Round(soundVolume);
        volumeSlider.value = (soundVolume + 80) / 100;

        volumeValueLabel.text = (soundVolume + 80) + " %";

        renderScaleSlider.value = urpAsset.renderScale;
        renderScaleLabel.text = (int)(urpAsset.renderScale * 100) + " %";

        if (YandexGame.SDKEnabled)
        {
            if (Application.isMobilePlatform)
            {
                anitAliasingToggle.isOn = YandexGame.savesData.antiAliasingPhone;

            }
            else
            {
                anitAliasingToggle.isOn = YandexGame.savesData.antiAliasingPC;
            }
        }
    }

    private void OnVolumeSliderChanged(float value)
    {
        masterMixer.SetFloat("VolumeMixer", value * 100 - 80);
        volumeValueLabel.text = MathF.Round(value * 100) + " %";
    }
    private void OnRenderScaleSliderChanged(float value)
    {
        urpAsset.renderScale = value;
        renderScaleLabel.text = MathF.Round(value * 100) + " %";
    }

    private void OnAntiAliasingToggleChanged(bool value)
    {
        if (Application.isMobilePlatform)
        {
            if (value)
                urpAsset.msaaSampleCount = 2;
            else
                urpAsset.msaaSampleCount = 1;
            YandexGame.savesData.antiAliasingPhone = value;

        }
        else
        {
            if (value)
                urpAsset.msaaSampleCount = 2;
            else
                urpAsset.msaaSampleCount = 1;
            YandexGame.savesData.antiAliasingPC = value;
        }
    }
}
