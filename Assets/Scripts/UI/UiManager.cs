using ED;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject levelSelectingPage;
    [SerializeField] private GameObject controlsPage;

    [SerializeField] private GameObject carSelectingPage;
    [SerializeField] private GameObject carsContainer;

    [SerializeField] private GameObject pausePanel;


    [Header("Settings component references")]
    [SerializeField] private UniversalRenderPipelineAsset urpAsset;
    [SerializeField] private AudioMixer mainMixer;



    public void SwitchMainPage(bool enabled)
    {
        if (mainPage != null)
            mainPage.SetActive(enabled);
    }
    public void SwitchSettingsPage(bool enabled)
    {
        if (settingsPage != null)
        {
            settingsPage.SetActive(enabled);
            if (!enabled)
            {
                Debug.Log("Savind settings data");

                float volume;
                mainMixer.GetFloat("VolumeMixer", out volume);

                bool antiAliasingEnable = urpAsset.msaaSampleCount == 1 ? false : true;

                GameSettings.SaveSettingsData(volume, urpAsset.renderScale, antiAliasingEnable);
            }
        }
    }
    public void SwitchLevelSelectingPage(bool enabled)
    {
        if (levelSelectingPage != null)
            levelSelectingPage.SetActive(enabled);

    }

    public void SwitchCarSelectingPage(bool enabled)
    {
        if (carsContainer != null && carSelectingPage != null)
        {
            carsContainer.SetActive(enabled);
            carSelectingPage.SetActive(enabled);
        }

    }

    public void SwitchControlsPage(bool enabled)
    {
        if (controlsPage != null)
            controlsPage.SetActive(enabled);
    }
}
