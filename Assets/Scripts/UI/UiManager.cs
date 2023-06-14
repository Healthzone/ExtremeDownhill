using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using YG;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject levelSelectingPage;

    [SerializeField] private GameObject carSelectingPage;
    [SerializeField] private GameObject carsContainer;

    [Header("Settings component references")]
    [SerializeField] private UniversalRenderPipelineAsset urpAsset;
    [SerializeField] private AudioMixer mainMixer;


    public void SwitchMainPage(bool enabled)
    {
        mainPage.SetActive(enabled);
    }
    public void SwitchSettingsPage(bool enabled)
    {
        settingsPage.SetActive(enabled);
        if (!enabled)
        {
            Debug.Log("Savind settings data");

            float volume;
            mainMixer.GetFloat("VolumeMixer", out volume);

            GameSettings.SaveSettingsData(volume, urpAsset.renderScale);
        }
    }
    public void SwitchLevelSelectingPage(bool enabled)
    {
        levelSelectingPage.SetActive(enabled);

    }

    public void SwitchCarSelectingPage(bool enabled)
    {
        carsContainer.SetActive(enabled);
        carSelectingPage.SetActive(enabled);

    }
}
