using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    private static bool isLevelLoading = false;

    public static bool IsLevelLoading { get => isLevelLoading; set => isLevelLoading = value; }

    private void OnEnable()
    {
        SceneTransitionManager.OnSceneStartLoading.AddListener(SetLevelLoadBool);
    }
    private void OnDisable()
    {
        SceneTransitionManager.OnSceneStartLoading.RemoveListener(SetLevelLoadBool);
    }

    private void SetLevelLoadBool()
    {
        isLevelLoading = true;
    }

    private void Start()
    {
        isLevelLoading = false;
        AudioListener.pause = false;
    }
}
