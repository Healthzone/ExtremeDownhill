using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CarSelector : MonoBehaviour
{
    public static UnityEvent OnPlayerCarSpawned = new UnityEvent();
    [SerializeField] private GameObject[] cars;


    public void OnEnable()
    {
        SceneManager.sceneLoaded += InitPlayer;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= InitPlayer;
    }

    public void InitPlayer(Scene scene, LoadSceneMode mode)
    {
        Instantiate(cars[PlayerLevelData.SelectedVehicle], new Vector3(0, 2f, 0), Quaternion.identity);
        DynamicGI.UpdateEnvironment();
        OnPlayerCarSpawned?.Invoke();

    }
}
