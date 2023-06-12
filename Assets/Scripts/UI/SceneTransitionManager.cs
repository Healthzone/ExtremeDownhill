using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    public void StartLoadingLevel()
    {
        if (PlayerLevelData.SelectedLevel != 0)
            SceneTransition.SwitchToScene(PlayerLevelData.SelectedLevel.ToString());
        else
            SceneTransition.SwitchToScene("1");
    }

    public void BackToMainMenu()
    {
        SceneTransition.SwitchToScene("Menu");
    }
}
