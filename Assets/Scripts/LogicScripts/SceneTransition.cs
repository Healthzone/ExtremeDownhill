using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image loadingProgressBar;
    [SerializeField] private GameObject loadingPanel;

    [SerializeField] private float waitDelay = 1f;

    private static SceneTransition _instance;
    private AsyncOperation loadSceneOperation;

    public static void SwitchToScene(string sceneName)
    {
        Debug.Log("Loading level: " + sceneName);
        _instance.loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
         _instance.loadSceneOperation.allowSceneActivation = false;
        _instance.loadingPanel.SetActive(true);

        //_instance.loadSceneOperation.allowSceneActivation = false;
        //DOTween.Sequence()
        //    .Append(_instance.canvasGroup.DOFade(1, 0.1f))
        //    .OnComplete(() => _instance.OnAnimationOver());

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

    IEnumerator WaitSomeTimeAfterLoadedScene()
    {
        yield return new WaitForSeconds(waitDelay);
        loadSceneOperation.allowSceneActivation = true;
       // yield return null ;
    }
    private void OnAnimationOver()
    {
        _instance.loadSceneOperation.allowSceneActivation = true;
    }
}
