using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelEndUI : MonoBehaviour
{
    [SerializeField] private GameObject UICanvasGameObject;
    private void OnEnable()
    {
        LevelEnding.OnLevelEnd.AddListener(SwitchUICanvas);
    }
    private void OnDisable()
    {
        LevelEnding.OnLevelEnd.RemoveListener(SwitchUICanvas);

    }

    private void SwitchUICanvas()
    {
        Time.timeScale = 0f;

        if(!Application.isMobilePlatform)
            Cursor.lockState = CursorLockMode.None;

        UICanvasGameObject.SetActive(true);
    }
}
