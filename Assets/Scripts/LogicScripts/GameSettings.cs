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
                if (YandexGame.savesData.antiAliasingPhone)
                    urpAsset.msaaSampleCount = 2;
                else
                    urpAsset.msaaSampleCount = 1;
            }
            else
            {
                mainMixer.SetFloat("VolumeMixer", YandexGame.savesData.volumePc);
                urpAsset.renderScale = YandexGame.savesData.renderScalePc;
                if (YandexGame.savesData.antiAliasingPC)
                    urpAsset.msaaSampleCount = 2;
                else
                    urpAsset.msaaSampleCount = 1;
            }
        }

        void Start()
        {
            if (YandexGame.SDKEnabled)
                InitSettings();
        }

        public static void SaveSettingsData(float volume, float renderScale, bool antiAliasingEnable)
        {
            if (Application.isMobilePlatform)
            {
                YandexGame.savesData.volumePhone = volume;
                YandexGame.savesData.renderScalePhone = renderScale;
                YandexGame.savesData.antiAliasingPhone = antiAliasingEnable;
            }
            else
            {
                YandexGame.savesData.renderScalePc = renderScale;
                YandexGame.savesData.volumePc = volume;
                YandexGame.savesData.antiAliasingPC = antiAliasingEnable;
            }
            YandexGame.SaveProgress();
            OnGameSettingsChanged.Invoke();
        }
    }
}

