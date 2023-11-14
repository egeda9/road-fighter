using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    private void OnTriggerEnter(Component other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (SaveScript.HalfWayActivated)
            {
                SaveScript.HalfWayActivated = false;
                SaveScript.AddScore = true;
                SaveScript.ReduceFuel = true;
                SaveScript.Fuel = 800;
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
}
