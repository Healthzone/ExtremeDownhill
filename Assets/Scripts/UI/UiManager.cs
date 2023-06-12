using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject settingsPage;
    [SerializeField] private GameObject levelSelectingPage;

    [SerializeField] private GameObject carSelectingPage;
    [SerializeField] private GameObject carsContainer;


    public void SwitchMainPage(bool enabled)
    {
        mainPage.SetActive(enabled);
    }
    public void SwitchSettingsPage(bool enabled)
    {
        settingsPage.SetActive(enabled);
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
