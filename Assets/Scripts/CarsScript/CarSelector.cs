using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] cars;

    public void InitPlayer()
    {
        Instantiate(cars[PlayerLevelData.SelectedVehicle], Vector3.zero, Quaternion.identity);


    }
}
