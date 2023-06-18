using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class CarSelection : MonoBehaviour
{

    [SerializeField] private Transform carsContainer;

    private int currentCar;

    private void Start()
    {
        SelectCar(0);
        PlayerLevelData.SelectedVehicle = 0;
    }

    private void SelectCar(int index)
    {
        for (int i = 0; i < carsContainer.childCount; i++)
        {
            carsContainer.GetChild(i).gameObject.SetActive(i == index);
        }
    }


    public void ChangeCar(int change)
    {
        currentCar += change;
        if (currentCar > carsContainer.childCount - 1)
            currentCar = 0;
        else if (currentCar < 0)
            currentCar = carsContainer.childCount - 1;

        PlayerLevelData.SelectedVehicle = currentCar;
        Debug.Log(currentCar);
        SelectCar(currentCar);
    }
}
