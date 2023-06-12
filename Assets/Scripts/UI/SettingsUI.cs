using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider renderScaleSlider;


    [SerializeField] private TextMeshProUGUI volumeValueLabel;
    [SerializeField] private TextMeshProUGUI renderScaleLabel;



    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private UniversalRenderPipelineAsset urpAsset;

    private void OnEnable()
    {
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        renderScaleSlider.onValueChanged.AddListener(OnRenderScaleSliderChanged);
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
        volumeSlider.value = (soundVolume + 80f) / 100;

        volumeValueLabel.text = MathF.Round(soundVolume + 80) + " %";

        renderScaleSlider.value = urpAsset.renderScale;
        renderScaleLabel.text = (int)(urpAsset.renderScale * 100) + " %";

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
}
