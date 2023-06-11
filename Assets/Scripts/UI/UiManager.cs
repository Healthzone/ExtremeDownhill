using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject settingsPage;


    public void SwitchMainPage(bool enable)
    {
        mainPage.SetActive(enable);
    }
    public void SwitchSettingsPage(bool enable)
    {
        settingsPage.SetActive(enable);
    }
}
