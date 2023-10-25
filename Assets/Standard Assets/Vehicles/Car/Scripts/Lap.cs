using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private void OnTriggerEnter(Component other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SaveScript.AddScore = true;
            SaveScript.Fuel = 100000;
            SaveScript.LastLapM = SaveScript.LapTimeMinutes;
            SaveScript.LastLapS = SaveScript.LapTimeSeconds;
            SaveScript.LapNumber++;
            SaveScript.LapChange = true;

            if (SaveScript.LapNumber == 2)
            {
                SaveScript.BestLapTimeM = SaveScript.LastLapM;
                SaveScript.BestLapTimeS = SaveScript.LastLapS;
            }

            SaveScript.CheckpointPass1 = false;
            SaveScript.CheckpointPass2 = false;
            SaveScript.LastCheckPoint1 = SaveScript.ThisCheckPoint1;
            SaveScript.LastCheckPoint2 = SaveScript.ThisCheckPoint2;
        }
    }
}
