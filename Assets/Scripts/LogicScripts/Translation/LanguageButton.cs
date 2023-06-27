using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LanguageButton : MonoBehaviour
{
    private void OnEnable() => YandexGame.SwitchLangEvent += ChangeLanguageGameObject;

    private void OnDisable() => YandexGame.SwitchLangEvent -= ChangeLanguageGameObject;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            ChangeLanguageGameObject(YandexGame.savesData.language);
    }

    private void ChangeLanguageGameObject(string lang)
    {
        if (lang == GetComponent<Image>().sprite.name)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
