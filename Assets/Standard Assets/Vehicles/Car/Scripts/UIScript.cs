using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image SpeedRing;
    public Text SpeedText;
    public Text GearText;
    public Text LapNumberText;
    private float _displaySpeed;
    public int TotalLaps = 3;

    // Start is called before the first frame update
    void Start()
    {
        SpeedRing.fillAmount = 0;
        SpeedText.text = "0";
        GearText.text = "1";
        LapNumberText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        this._displaySpeed = SaveScript.Speed / SaveScript.TopSpeed;
        SpeedRing.fillAmount = _displaySpeed;
        SpeedText.text = Mathf.Round(SaveScript.Speed).ToString(CultureInfo.InvariantCulture);
        GearText.text = (SaveScript.Gear + 1).ToString();
        LapNumberText.text = SaveScript.LapNumber.ToString();
    }
}
