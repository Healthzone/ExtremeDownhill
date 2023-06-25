using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class YandexMetrika : MonoBehaviour
{
    private static bool isFirstLoad = true;

    private void Start()
    {
        if (isFirstLoad)
        {
            YandexMetrica.Send("Loaded");
            isFirstLoad = false;
            Debug.Log("Game loaded");
        }
    }
}
