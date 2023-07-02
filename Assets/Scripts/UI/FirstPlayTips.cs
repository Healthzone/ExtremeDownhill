using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class FirstPlayTips : MonoBehaviour
{
    [SerializeField] private GameObject controlWindow;
     
    private void Start()
    {
        if (YandexGame.savesData.isFirstPlay)
        {
            if(controlWindow != null)
            controlWindow.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            if(controlWindow != null )
                Destroy(controlWindow);
        }
    }

    public void CloseControlTipWindow()
    {
        controlWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        YandexGame.savesData.isFirstPlay = false;
        YandexGame.SaveProgress();
    }

}
