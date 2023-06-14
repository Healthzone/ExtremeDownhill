using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;

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

                GameSettings.SaveSettingsData(volume, urpAsset.renderScale);
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
}
