using PG;
using PG.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using YG;

public class PauseUI : MonoBehaviour
{
    public static UnityEvent OnGamePaused = new UnityEvent();

    [SerializeField] private GameObject PauseCanvasGameObject;
    [SerializeField] private GameObject pausePage;
    [SerializeField] private AudioMixer mainMixer;


    private static bool isPaused = false;
    private bool isLevelEnded = false;

    private static PauseUI _instance;

    public static PauseUI Instance { get => _instance; }
    public static bool IsPaused { get => isPaused;}

    private void OnEnable()
    {
        LevelEnding.OnLevelEnd.AddListener(LevelEnd);
    }
    private void OnDisable()
    {
        LevelEnding.OnLevelEnd.RemoveListener(LevelEnd);
    }

    private void LevelEnd()
    {
        isLevelEnded = true;
    }

    private void Start()
    {
        _instance = this;
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isLevelEnded && !GameStates.IsLevelLoading && !PlayerDeadTrigger.IsPlayerDead)
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

        _instance.PauseCanvasGameObject.SetActive(true);
        _instance.pausePage.SetActive(true);
        isPaused = true;

        OnGamePaused?.Invoke();

    }

    public void UnpauseGame()
    {
        Time.timeScale = 1f;
        if (!Application.isMobilePlatform)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        PauseCanvasGameObject.SetActive(false);
        pausePage.SetActive(false);
        isPaused = false;


        OnGamePaused?.Invoke();

    }
}
