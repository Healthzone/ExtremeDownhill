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

    [SerializeField] private GameObject levelEndPage;

    [Header("Settings component references")]
    [SerializeField] private UniversalRenderPipelineAsset urpAsset;
    [SerializeField] private AudioMixer mainMixer;

    private void OnEnable()
    {
        LevelEnding.OnLevelEnd.AddListener(SwitchLevelEndPanel);
    }
    private void OnDisable()
    {
        LevelEnding.OnLevelEnd.RemoveListener(SwitchLevelEndPanel);
    }

    private void SwitchLevelEndPanel()
    {
        if (levelEndPage != null)
            levelEndPage.SetActive(true);
    }

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
