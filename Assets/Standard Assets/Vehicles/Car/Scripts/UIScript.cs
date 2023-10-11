using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Image SpeedRing;
    private float _displaySpeed;

    // Start is called before the first frame update
    void Start()
    {
        SpeedRing.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this._displaySpeed = SaveScript.Speed / SaveScript.TopSpeed;
        SpeedRing.fillAmount = _displaySpeed;
    }
}
