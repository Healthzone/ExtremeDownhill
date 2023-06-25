using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class YandexMetrikaLevelComplete : MonoBehaviour
{
    private void OnEnable()
    {
        LevelEnding.OnLevelEnd.AddListener(LevelCompleted);
    }

    private void OnDisable()
    {
        LevelEnding.OnLevelEnd.RemoveListener(LevelCompleted);
    }

    private void LevelCompleted()
    {
        if(YandexGame.savesData.unlockedLastLevel == 2)
        {
            Debug.Log("First level completed");
            YandexMetrica.Send("FirstLevelCompleted");
        }

    }
}
