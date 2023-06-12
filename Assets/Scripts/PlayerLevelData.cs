using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLevelData
{
    private static string selectedLevel;
    private static int selectedVehicle;

    public static string SelectedLevel { get => selectedLevel; set => selectedLevel = value; }
    public static int SelectedVehicle { get => selectedVehicle; set => selectedVehicle = value; }
}
