using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LanguageChanger : MonoBehaviour
{
    [SerializeField] private YandexGame yandexGame;
    [SerializeField] private GameObject ruLanguageButton;
    [SerializeField] private GameObject enLanguageButton;
    [SerializeField] private GameObject trLanguageButton;
    public void ChangeLanguage(string lang)
    {
        switch (lang)
        {
            case "ru":
                yandexGame._SwitchLanguage(lang);
                enLanguageButton.SetActive(false);
                trLanguageButton.SetActive(false);
                ruLanguageButton.SetActive(true);
                break;
            case "en":
                yandexGame._SwitchLanguage(lang);
                enLanguageButton.SetActive(true);
                ruLanguageButton.SetActive(false);
                trLanguageButton.SetActive(false);
                break;
            case "tr":
                yandexGame._SwitchLanguage(lang);
                trLanguageButton.SetActive(true);
                enLanguageButton.SetActive(false);
                ruLanguageButton.SetActive(false);
                break;
            default:
                enLanguageButton.SetActive(false);
                trLanguageButton.SetActive(false);
                ruLanguageButton.SetActive(true);
                yandexGame._SwitchLanguage("ru");
                break;
        }
    }
}
