using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LanguageButton : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += ChangeLanguageGameObject;

    private void OnDisable() => YandexGame.GetDataEvent -= ChangeLanguageGameObject;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            ChangeLanguageGameObject();
        }

    }

    private void ChangeLanguageGameObject()
    {
        YandexGame.SwitchLanguage(YandexGame.savesData.language);
        if (YandexGame.savesData.language == GetComponent<Image>().sprite.name)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
