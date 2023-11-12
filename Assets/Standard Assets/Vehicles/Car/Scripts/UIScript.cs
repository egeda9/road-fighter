using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private const float DefaultScore = 100f;
    private const float DefaultFuel = 150f;
    private const string InitialFuel = "800";

    public Image SpeedRing;
    public Text SpeedText;
    public Text GearText;
    public Text LapNumberText;
    public Text LapTimeMinutesText;
    public Text LapTimeSecondsText;
    public Text RaceTimeMinutesText;
    public Text RaceTimeSecondsText;
    public Text BestLapTimeMinutesText;
    public Text BestLapTimeSecondsText;
    public Text CheckPointTime;
    public Text CheckPointScore;
    public Text CheckPointFuel;
    public Text ScoreText;
    public Text FuelText;
    public GameObject CheckPointDisplay;
    public GameObject CheckPointScoreDisplay;
    public GameObject CheckPointFuelDisplay;
    public GameObject WrongWayText;
    private float _displaySpeed;
    public int TotalLaps = 3;

    // Start is called before the first frame update
    void Start()
    {
        SpeedRing.fillAmount = 0;
        SpeedText.text = "0";
        GearText.text = "1";
        LapNumberText.text = "0";
        ScoreText.text = "0";
        FuelText.text = InitialFuel;
        CheckPointDisplay.SetActive(false);
        CheckPointScoreDisplay.SetActive(false);
        CheckPointFuelDisplay.SetActive(false);
        WrongWayText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Speedometer
        this._displaySpeed = SaveScript.Speed / SaveScript.TopSpeed;
        SpeedRing.fillAmount = _displaySpeed;
        SpeedText.text = Mathf.Round(SaveScript.Speed).ToString(CultureInfo.InvariantCulture);
        GearText.text = (SaveScript.Gear + 1).ToString();
        
        // LapNumber
        LapNumberText.text = SaveScript.LapNumber.ToString();

        // LapTime
        switch (SaveScript.LapTimeMinutes)
        {
            case <= 9:
                LapTimeMinutesText.text = $"0{Mathf.Round(SaveScript.LapTimeMinutes)}:";
                break;
            case >= 10:
                LapTimeMinutesText.text = $"{Mathf.Round(SaveScript.LapTimeMinutes)}:";
                break;
        }

        switch (SaveScript.LapTimeSeconds)
        {
            case <= 9:
                LapTimeSecondsText.text = $"0{Mathf.Round(SaveScript.LapTimeSeconds)}";
                break;
            case >= 10:
                LapTimeSecondsText.text = Mathf.Round(SaveScript.LapTimeSeconds).ToString(CultureInfo.InvariantCulture);
                break;
        }

        // RaceTime
        switch (SaveScript.RaceTimeMinutes)
        {
            case <= 9:
                RaceTimeMinutesText.text = $"0{Mathf.Round(SaveScript.RaceTimeMinutes)}:";
                break;
            case >= 10:
                RaceTimeMinutesText.text = $"{Mathf.Round(SaveScript.RaceTimeMinutes)}:";
                break;
        }

        switch (SaveScript.RaceTimeSeconds)
        {
            case <= 9:
                RaceTimeSecondsText.text = $"0{Mathf.Round(SaveScript.RaceTimeSeconds)}";
                break;
            case >= 10:
                RaceTimeSecondsText.text = Mathf.Round(SaveScript.RaceTimeSeconds).ToString(CultureInfo.InvariantCulture);
                break;
        }

        // Best LapTime calculations
        if (SaveScript.LastLapM == SaveScript.BestLapTimeM)
        {
            if (SaveScript.LastLapS == SaveScript.BestLapTimeS)
            {
                SaveScript.BestLapTimeS = SaveScript.LastLapS;
            }
        }

        if (SaveScript.LastLapM == SaveScript.BestLapTimeM)
        {
            SaveScript.BestLapTimeM = SaveScript.LastLapM;
            SaveScript.BestLapTimeS = SaveScript.LastLapS;
        }

        // Display Best LapTime
        switch (SaveScript.BestLapTimeM)
        {
            case <= 9:
                BestLapTimeMinutesText.text = $"0{Mathf.Round(SaveScript.BestLapTimeM)}";
                break;
            case >= 10:
                BestLapTimeMinutesText.text = Mathf.Round(SaveScript.BestLapTimeM).ToString(CultureInfo.InvariantCulture);
                break;
        }

        switch (SaveScript.BestLapTimeS)
        {
            case <= 9:
                BestLapTimeSecondsText.text = $"0{Mathf.Round(SaveScript.BestLapTimeS)}";
                break;
            case >= 10:
                BestLapTimeSecondsText.text = Mathf.Round(SaveScript.BestLapTimeS).ToString(CultureInfo.InvariantCulture);
                break;
        }

        // Checkpoint 1
        if (SaveScript.CheckpointPass1)
        {
            SaveScript.CheckpointPass1 = true;
            CheckPointDisplay.SetActive(true);

            if (SaveScript.ThisCheckPoint1 > SaveScript.LastCheckPoint1)
            {
                CheckPointTime.color = Color.red;
                CheckPointTime.text = $"-{SaveScript.ThisCheckPoint1 - SaveScript.LastCheckPoint1}";
            }

            if (SaveScript.ThisCheckPoint1 < SaveScript.LastCheckPoint1)
            {
                CheckPointTime.color = Color.green;
                CheckPointTime.text = $"+{SaveScript.ThisCheckPoint1 - SaveScript.LastCheckPoint1}";
            }

            SaveScript.CheckpointPass1 = false;
            StartCoroutine(CheckPointOff());
            AddScoreOnCheckPoint();
            AddFuelOnCheckPoint();
        }

        // Checkpoint 2
        if (SaveScript.CheckpointPass2)
        {
            SaveScript.CheckpointPass2 = true;
            CheckPointDisplay.SetActive(true);

            if (SaveScript.ThisCheckPoint2 > SaveScript.LastCheckPoint2)
            {
                CheckPointTime.color = Color.red;
                CheckPointTime.text = $"-{SaveScript.ThisCheckPoint2 - SaveScript.LastCheckPoint2}";
            }

            if (SaveScript.ThisCheckPoint2 < SaveScript.LastCheckPoint2)
            {
                CheckPointTime.color = Color.green;
                CheckPointTime.text = $"+{SaveScript.ThisCheckPoint2 - SaveScript.LastCheckPoint2}";
            }

            SaveScript.CheckpointPass2 = false;
            StartCoroutine(CheckPointOff());
            AddScoreOnCheckPoint();
            AddFuelOnCheckPoint();
        }

        // Score
        if (SaveScript.AddScore && SaveScript.Speed > 10)
        {
            StartCoroutine(IncreaseScore());
        }

        if (SaveScript.ReduceScore)
        {
            ReduceScoreOnCheckPoint();
        }

        if (SaveScript.LapChange && SaveScript.LapNumber >= 2)
        {
            AddScoreOnCheckPoint();
            AddFuelOnCheckPoint();
        }

        // Fuel
        if (SaveScript.ReduceFuel && SaveScript.Speed > 5)
        {
            StartCoroutine(ReduceFuel());
        }

        // Wrong way message
        if (SaveScript.WrongWay)
        {
            WrongWayText.SetActive(true);
        }

        if (!SaveScript.WrongWay)
        {
            WrongWayText.SetActive(false);
        }
    }

    private void AddScoreOnCheckPoint()
    {
        CheckPointScoreDisplay.SetActive(true);
        CheckPointScore.color = Color.green;
        CheckPointScore.text = $"+{DefaultScore}P";
        SaveScript.Score += DefaultScore;
        ScoreText.text = SaveScript.Score.ToString(CultureInfo.InvariantCulture);
        StartCoroutine(CheckPointScoreOff());
    }

    private void ReduceScoreOnCheckPoint()
    {
        CheckPointScoreDisplay.SetActive(true);
        CheckPointScore.color = Color.red;
        CheckPointScore.text = $"-{DefaultScore}P";
        SaveScript.Score -= DefaultScore;
        ScoreText.text = SaveScript.Score.ToString(CultureInfo.InvariantCulture);
        StartCoroutine(CheckPointScoreOff());
    }

    private void AddFuelOnCheckPoint()
    {
        CheckPointFuelDisplay.SetActive(true);
        CheckPointFuel.color = Color.green;
        CheckPointFuel.text = $"+{DefaultFuel}F";
        SaveScript.Fuel += DefaultFuel;
        FuelText.text = SaveScript.Fuel.ToString(CultureInfo.InvariantCulture);
        StartCoroutine(CheckPointFuelOff());
    }

    private IEnumerator CheckPointOff()
    {
        yield return new WaitForSeconds(1f);
        CheckPointDisplay.SetActive(false);
    }

    private IEnumerator CheckPointScoreOff()
    {
        yield return new WaitForSeconds(1f);
        CheckPointScoreDisplay.SetActive(false);
    }

    private IEnumerator CheckPointFuelOff()
    {
        yield return new WaitForSeconds(1f);
        CheckPointFuelDisplay.SetActive(false);
    }

    private IEnumerator IncreaseScore()
    {
        yield return new WaitForSeconds(3f);
        ScoreText.text = SaveScript.Score++.ToString(CultureInfo.InvariantCulture);
    }

    private IEnumerator ReduceFuel()
    {
        yield return new WaitForSeconds(3f);
        FuelText.text = SaveScript.Fuel--.ToString(CultureInfo.InvariantCulture);
    }
}
