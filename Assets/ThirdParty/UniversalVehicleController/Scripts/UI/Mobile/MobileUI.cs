using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace PG.UI
{
    public class MobileUI : MonoBehaviour
    {
        public CarControllerInput UserInput;
        public PlayerController PlayerController;
        public TextMeshProUGUI CurrentControlText;
        public List<BaseControls> AllControls;

        [Header("Buttons")]
        public Button ChangeViewBtn;
        public Button OpenMenuBtn;

        public Button RestartSceneBtn;



        [Space(15)]
        public MobileButtonsPanel mobileButtonsPanel;

        int SelectedIndex = 0;
        public Button SelectNextControl;

        private void OnEnable()
        {
            LevelEnding.OnLevelEnd.AddListener(SwitchMobileButtons);
            PauseUI.OnGamePaused.AddListener(SwitchMobileButtons);
        }


        private void OnDisable()
        {
            LevelEnding.OnLevelEnd.RemoveListener(SwitchMobileButtons);
            PauseUI.OnGamePaused.RemoveListener(SwitchMobileButtons);

        }

        private void SwitchMobileButtons()
        {
            mobileButtonsPanel.gameObject.SetActive(!mobileButtonsPanel.gameObject.activeInHierarchy);
        }

        private void Awake()
        {
            gameObject.SetActive(GameSettings.IsMobilePlatform);

            if (!gameObject.activeInHierarchy)
            {
                return;
            }

            foreach (var controls in AllControls)
            {
                controls.Init(UserInput);
            }
        }

        void Start()
        {
            if (!gameObject.activeInHierarchy)
            {
                return;
            }

            if (!PlayerController)
            {
                PlayerController = GetComponentInParent<PlayerController>();
            }

            SelectNextControl.onClick.AddListener(OnSelectNextControl);
            SelectedIndex = PlayerPrefs.GetInt("MobileControlsIndex", 0);
            SelectControl(SelectedIndex);

            
            if (ChangeViewBtn)
            {
                ChangeViewBtn.onClick.AddListener(() => UserInput.ChangeView());
            }
            
            if (RestartSceneBtn)
            {
                RestartSceneBtn.onClick.AddListener(() => GameController.Instance.RestartScene());
            }

            if (OpenMenuBtn)
            {
                OpenMenuBtn.onClick.AddListener(() => SetGamePause());
            }
        }

        private void SetGamePause()
        {
            PauseUI.SetPauseGame();
            mobileButtonsPanel.gameObject.SetActive(false);
        }

        void OnSelectNextControl()
        {
            SelectedIndex = MathExtentions.Repeat(SelectedIndex + 1, 0, AllControls.Count - 1);
            PlayerPrefs.SetInt("MobileControlsIndex", SelectedIndex);
            SelectControl(SelectedIndex);
        }

        void SelectControl(int index)
        {
            for (int i = 0; i < AllControls.Count; i++)
            {
                AllControls[i].SetActive(index == i);
                if (AllControls[i].gameObject.activeInHierarchy)
                {
                    CurrentControlText.text = AllControls[i].Name;
                }
            }
        }
    }
}
