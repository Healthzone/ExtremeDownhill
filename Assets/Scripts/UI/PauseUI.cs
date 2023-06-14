using PG;
using PG.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using YG;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject PauseCanvasGameObject;
    [SerializeField] private AudioMixer mainMixer;

    private CameraController cameraController;
    private MobileUI mobileUI;


    private bool isPaused = false;

    private static PauseUI _instance;

    private void Start()
    {
        cameraController = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraController>();

        if (Application.isMobilePlatform)
            mobileUI = GameObject.FindGameObjectWithTag("MobileUI").GetComponent<MobileUI>();

        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            if (!isPaused)
                SetPauseGame();
            else
                UnpauseGame();
    }

    public static void SetPauseGame()
    {
        Time.timeScale = 0f;

        if (!Application.isMobilePlatform)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        _instance.mainMixer.SetFloat("MainMixer", -80f);
        _instance.PauseCanvasGameObject.SetActive(true);
        _instance.isPaused = true;
        if (_instance.cameraController != null)
            _instance.cameraController.enabled = false;

    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        if (!Application.isMobilePlatform)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            if (mobileUI == null)
                mobileUI = GameObject.FindGameObjectWithTag("MobileUI").GetComponent<MobileUI>();

            mobileUI.mobileButtonsPanel.gameObject.SetActive(true);

        }

        mainMixer.SetFloat("MainMixer", 0f);

        PauseCanvasGameObject.SetActive(false);
        isPaused = false;
        if (cameraController != null)
            cameraController.enabled = true;

    }
}
