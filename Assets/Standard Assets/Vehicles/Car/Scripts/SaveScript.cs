using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using Time = UnityEngine.Time;

public class SaveScript : MonoBehaviour
{
    public static float Speed;
    public static float TopSpeed;
    public static int Gear;
    public static int LapNumber;
    public static bool LapChange;
    public static float LapTimeMinutes;
    public static float LapTimeSeconds;
    public static float RaceTimeMinutes;
    public static float RaceTimeSeconds;
    public static float BestLapTimeM;
    public static float BestLapTimeS;
    public static float LastLapM;
    public static float LastLapS;
    public static float GameTime;
    public static float LastCheckPoint1;
    public static float ThisCheckPoint1;
    public static float LastCheckPoint2;
    public static float ThisCheckPoint2;
    public static bool CheckpointPass1;
    public static bool CheckpointPass2;
    public static float Score;
    public static bool AddScore;
    public static bool AddFuel;
    public static bool ReduceScore;
    public static float Fuel;
    public static bool ReduceFuel;
    public static bool Rumble1;
    public static bool Rumble2;
    public static bool OnTheRoad = true;
    public static bool OnTheTerrain;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (LapChange)
        {
            LapChange = false;
            LapTimeMinutes = 0f;
            LapTimeSeconds = 0f;
            GameTime = 0f;
        }

        if (LapNumber >= 1)
        {
            LapTimeSeconds += 1 * Time.deltaTime;
            RaceTimeSeconds += 1 * Time.deltaTime;
            GameTime += 1 * Time.deltaTime;
        }

        if (LapTimeSeconds > 59)
        {
            LapTimeSeconds = 0f;
            LapTimeMinutes++;
        }

        if (RaceTimeSeconds > 59)
        {
            RaceTimeSeconds = 0f;
            RaceTimeMinutes++;
        }
    }
}
