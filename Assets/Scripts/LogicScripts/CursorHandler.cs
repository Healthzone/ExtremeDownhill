using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class CursorHandler : MonoBehaviour
{
    YandexGame yg;
    private void Start()
    {
        yg.GetComponent<YandexGame>();
        yg.CloseFullscreenAd.AddListener(HideCursor);
        yg.OpenFullscreenAd.AddListener(UnhideCursor);
    }


    private void OnDisable()
    {
        yg.CloseFullscreenAd.RemoveListener(HideCursor);
    }
    private void UnhideCursor()
    {
        if (!Application.isMobilePlatform)
            Cursor.lockState = CursorLockMode.None;
    }

    private void HideCursor()
    {
        if(!Application.isMobilePlatform)
            Cursor.lockState = CursorLockMode.Locked;
    }
}
