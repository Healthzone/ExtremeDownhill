using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerLevelData
{
    private static int selectedLevel;
    private static int selectedVehicle;

    public static int SelectedLevel { get => selectedLevel; set => selectedLevel = value; }
    public static int SelectedVehicle { get => selectedVehicle; set => selectedVehicle = value; }
}
