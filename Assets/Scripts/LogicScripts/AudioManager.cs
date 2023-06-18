using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private void OnEnable()
    {
        LevelEnding.OnLevelEnd.AddListener(SwitchAudioVolumeMixer);
        PauseUI.OnGamePaused.AddListener(SwitchAudioVolumeMixer);
        PlayerDeadTrigger.OnPlayerDead.AddListener(SwitchAudioVolumeMixer);
        SceneTransitionManager.OnSceneStartLoading.AddListener(SwitchAudioVolumeMixer);
    }


    private void OnDisable()
    {
        LevelEnding.OnLevelEnd.RemoveListener(SwitchAudioVolumeMixer);
        PauseUI.OnGamePaused.RemoveListener(SwitchAudioVolumeMixer);
        PlayerDeadTrigger.OnPlayerDead.RemoveListener(SwitchAudioVolumeMixer);
        SceneTransitionManager.OnSceneStartLoading.RemoveListener(SwitchAudioVolumeMixer);
    }

    private void Start()
    {
        AudioListener.pause = false;
    }
    private void SwitchAudioVolumeMixer()
    {
        AudioListener.pause = !AudioListener.pause;
    }


}
