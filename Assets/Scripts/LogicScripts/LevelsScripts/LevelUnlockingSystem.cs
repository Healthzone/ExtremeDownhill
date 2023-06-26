using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LevelUnlockingSystem : MonoBehaviour
{
    [SerializeField] private GameObject LockImageGameObject;
    [SerializeField] private Button StartLevelButton;

    private void OnEnable()
    {
        YandexGame.GetDataEvent += UnlockLevel;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= UnlockLevel;
    }
    void Start()
    {

        if (YandexGame.SDKEnabled)
            UnlockLevel();
    }

    private void UnlockLevel()
    {
        if (YandexGame.savesData.unlockedLastLevel >= Convert.ToInt32(gameObject.name))
        {
            StartLevelButton.interactable = true;
            LockImageGameObject.SetActive(false);
        }
        else
        {
            LockImageGameObject.SetActive(true);
            StartLevelButton.interactable = false;
        }

    }
}
