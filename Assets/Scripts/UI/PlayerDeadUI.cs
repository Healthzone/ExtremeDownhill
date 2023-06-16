using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadUI : MonoBehaviour
{
    [SerializeField] private GameObject UIPlayerDeadCanvas;
    private void OnEnable()
    {
        PlayerDeadTrigger.OnPlayerDead.AddListener(SwitchUICanvas);
    }
    private void OnDisable()
    {
        PlayerDeadTrigger.OnPlayerDead.RemoveListener(SwitchUICanvas);

    }

    private void SwitchUICanvas()
    {
        Time.timeScale = 0f;

        if (!Application.isMobilePlatform)
            Cursor.lockState = CursorLockMode.None;

        UIPlayerDeadCanvas.SetActive(true);
    }
}
