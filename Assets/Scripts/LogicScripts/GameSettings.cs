using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using YG;

namespace ED
{
    public class GameSettings : MonoBehaviour
    {

        [SerializeField] UniversalRenderPipelineAsset urpAsset;
        [SerializeField] AudioMixer mainMixer;

        public static UnityEvent OnGameSettingsChanged = new UnityEvent();

        private void OnEnable()
        {
            YandexGame.GetDataEvent += InitSettings;
        }

        private void OnDisable()
        {
            YandexGame.GetDataEvent -= InitSettings;
        }

        private void InitSettings()
        {
            if (Application.isMobilePlatform)
            {
                mainMixer.SetFloat("VolumeMixer", YandexGame.savesData.volumePhone);
                urpAsset.renderScale = YandexGame.savesData.renderScalePhone;
            }
            else
            {
                mainMixer.SetFloat("VolumeMixer", YandexGame.savesData.volumePc);
                urpAsset.renderScale = YandexGame.savesData.renderScalePc;
            }
        }

        void Start()
        {
            if (YandexGame.SDKEnabled)
                InitSettings();
        }

        public static void SaveSettingsData(float volume, float renderScale)
        {
            if (Application.isMobilePlatform)
            {
                YandexGame.savesData.volumePhone = volume;
                YandexGame.savesData.renderScalePhone = renderScale;
            }
            else
            {
                YandexGame.savesData.renderScalePc = renderScale;
                YandexGame.savesData.volumePc = volume;
            }
            YandexGame.SaveProgress();
            OnGameSettingsChanged.Invoke();
        }
    }
}

