using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image loadingProgressBar;
    [SerializeField] private GameObject loadingPanel;

    [SerializeField] private float waitDelay = 1f;
    [SerializeField] private float waitDelayBeforeAds = 0.5f;
    [SerializeField] private float waitDelayAfterAds = 1f;

    private static SceneTransition _instance;
    private AsyncOperation loadSceneOperation;

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += PauseLoadingOnAd;
        YandexGame.CloseFullAdEvent += UnpauseLoadingAfterAds;
    }
    private void OnDisable()
    {
        YandexGame.OpenFullAdEvent -= PauseLoadingOnAd;
        YandexGame.CloseFullAdEvent -= UnpauseLoadingAfterAds;
    }

    public static void SwitchToScene(string sceneName)
    {
        Debug.Log("Loading level: " + sceneName);

        _instance.loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        _instance.loadSceneOperation.allowSceneActivation = false;
        _instance.loadingPanel.SetActive(true);

        _instance.StartCoroutine(_instance.ShowAdsOnLoading());

    }

    private void Start()
    {
        _instance = this;
    }
    private void Update()
    {
        if (loadSceneOperation != null)
        {
            loadingProgressBar.fillAmount = Mathf.Lerp(loadingProgressBar.fillAmount, loadSceneOperation.progress, Time.deltaTime * 5);

            StartCoroutine(WaitSomeTimeAfterLoadedScene());
        }

    }

    private void PauseLoadingOnAd()
    {
        _instance.loadSceneOperation.allowSceneActivation = false;
    }

    private void UnpauseLoadingAfterAds()
    {
        StartCoroutine(SetDelayAfterAds());
    }
    private IEnumerator SetDelayAfterAds()
    {
        yield return new WaitForSeconds(waitDelayAfterAds);
        _instance.loadSceneOperation.allowSceneActivation = true;
    }


    private IEnumerator ShowAdsOnLoading()
    {
        yield return new WaitForSeconds(waitDelayBeforeAds);
        YandexGame.FullscreenShow();

    }

    IEnumerator WaitSomeTimeAfterLoadedScene()
    {
        yield return new WaitForSeconds(waitDelay);
        if (YandexGame.nowFullAd)
            yield break;
        loadSceneOperation.allowSceneActivation = true;
    }
}
