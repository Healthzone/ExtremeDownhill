using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    public void StartLoadingLevel()
    {
        if (PlayerLevelData.SelectedLevel != "")
            SceneTransition.SwitchToScene(PlayerLevelData.SelectedLevel.ToString());
        else
            SceneTransition.SwitchToScene("1");
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        mixer.SetFloat("MainMixer", 0f);
        SceneTransition.SwitchToScene("Menu");
    }
}
