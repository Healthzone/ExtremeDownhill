using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using YG;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace PG
{
    /// <summary>
    /// The game controller is responsible for initializing the player's car.
    /// </summary>
    public class GameController : Singleton<GameController>
    {
        public Transform[] StartPositions;
        public List<CarController> AllCars = new List<CarController>();
        public bool m_SplitScreen;
        public static bool SplitScreen => Instance && Instance.m_SplitScreen && SoundHelper.SoundSupportSplitScreen && InputHelper.InputSupportSplitScreen;

        public InitializePlayer Player1 { get; private set; }
        public InitializePlayer Player2 { get; private set; }
        public CarController PlayerCar1 { get; private set; }
        public CarController PlayerCar2 { get; private set; }

        List<VehicleController> AllVehicles = new List<VehicleController>();

        void Start()
        {
            if (StartPositions == null || StartPositions.Length <= 0)
            {
                var respawns = GameObject.FindGameObjectsWithTag("Respawn");
                StartPositions = new Transform[respawns.Length];
                for (int i = 0; i < respawns.Length; i++)
                {
                    StartPositions[i] = respawns[i].transform;
                }
            }
            AllCars.RemoveAll(c => c == null);
            AllVehicles = FindObjectsOfType<VehicleController>().ToList();
            var allCars = FindObjectsOfType<CarController>().ToList();
            AllCars.AddRange(allCars.Where(c => !AllCars.Contains(c)));



            if (!PlayerCar1 && AllCars.Count == 0)
            {
                PlayerCar1 = Instantiate(B.GameSettings.AvailableVehicles.First(v => v as CarController) as CarController);
                if (StartPositions != null && StartPositions.Length > 0)
                {
                    PlayerCar1.transform.position = StartPositions[0].position;
                    PlayerCar1.transform.rotation = StartPositions[0].rotation;
                }
                AllVehicles.Add(PlayerCar1);
                AllCars.Add(PlayerCar1);
            }
            else if (!PlayerCar1)
            {
                PlayerCar1 = AllCars[0];
            }

            UpdateSelectedCars();

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            if (!Application.isMobilePlatform)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        public void SetNextCar()
        {
            if (PlayerCar1)
            {
                PlayerCar1.VehicleSFX.RemoveStudioListiner();
            }

            var index = PlayerCar1 ? AllCars.IndexOf(PlayerCar1) : 0;
            index = MathExtentions.Repeat(index + 1, 0, AllCars.Count - 1);

            PlayerCar1 = AllCars[index];
            UpdateSelectedCars();
        }

        void UpdateSelectedCars()
        {
            Player1 = UpdateSelectedCar(Player1, PlayerCar1);
            if (SplitScreen)
            {
                Player2 = UpdateSelectedCar(Player2, PlayerCar2);
            }
        }

        InitializePlayer UpdateSelectedCar(InitializePlayer player, CarController car)
        {
            Debug.Log(YandexGame.EnvironmentData.deviceType);
            if (!player)
            {
                PlayerController playerPrefab;

                playerPrefab = Application.isMobilePlatform ?
                    B.ResourcesSettings.PlayerControllerPrefab_ForMobile :
                    B.ResourcesSettings.PlayerControllerPrefab;

                player = GameObject.Instantiate(playerPrefab);
            }

            if (player.Initialize(car))
            {
                player.name = string.Format("PlayerController_{0}", player.Vehicle.name);
                Debug.LogFormat("Player for {0} is initialized", player.Vehicle.name);
            }

            return player;
        }

        public void RestartScene()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
    }

//#if UNITY_EDITOR

//    [CustomEditor(typeof(GameController))]
//    public class GameControllerEditor : Editor
//    {
//        public override void OnInspectorGUI()
//        {
//            base.OnInspectorGUI();
//            if ((target as GameController).m_SplitScreen)
//            {
//                if (!SoundHelper.SoundSupportSplitScreen)
//                {
//                    EditorGUILayout.HelpBox("Current SoundSystem does not support split screen. \nPlease Install the FMOD dependency (The documentation describes how to do this).", MessageType.Error);
//                }
//                if (!InputHelper.InputSupportSplitScreen)
//                {
//                    EditorGUILayout.HelpBox("Current InputSystem (Old input system) does not support split screen. \nPlease Install the NewInputSystem dependency (The documentation describes how to do this).", MessageType.Error);
//                }
//            }
//        }
//    }

//#endif
}
