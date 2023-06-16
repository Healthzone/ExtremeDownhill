using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static UnityEvent OnSceneStartLoading = new UnityEvent();
    [SerializeField] private AudioMixer mixer;
    public void StartLoadingLevel()
    {
        Time.timeScale = 1f;
        OnSceneStartLoading.Invoke();
        if (PlayerLevelData.SelectedLevel != "")
            SceneTransition.SwitchToScene(PlayerLevelData.SelectedLevel.ToString());
        else
            SceneTransition.SwitchToScene("1");
    }

    public void StartLoadingNextLevel()
    {
        Time.timeScale = 1f;
        OnSceneStartLoading.Invoke();
        if (PlayerLevelData.SelectedLevel != "")
            SceneTransition.SwitchToScene((Convert.ToInt32(SceneManager.GetActiveScene().name) + 1).ToString());
        else
            SceneTransition.SwitchToScene("1");
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        OnSceneStartLoading.Invoke();
        SceneTransition.SwitchToScene("Menu");
    }
}
