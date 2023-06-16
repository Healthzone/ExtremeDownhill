using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    private void OnEnable()
    {
        LevelEnding.OnLevelEnd.AddListener(SwitchAudioVolumeMixer);
        PauseUI.OnGamePaused.AddListener(SwitchAudioVolumeMixer);
    }


    private void OnDisable()
    {
        LevelEnding.OnLevelEnd.RemoveListener(SwitchAudioVolumeMixer);
        PauseUI.OnGamePaused.RemoveListener(SwitchAudioVolumeMixer);
    }

    private void Start()
    {
        mainMixer.SetFloat("MainMixer", 0f);
    }
    private void SwitchAudioVolumeMixer()
    {
        float currentVolume;

        if (mainMixer != null)
        {
            mainMixer.GetFloat("MainMixer", out currentVolume);
            Debug.Log(currentVolume);
            if (currentVolume == 0)
                mainMixer.SetFloat("MainMixer", -80f);
            else
                mainMixer.SetFloat("MainMixer", 0f);
        }
    }


}
