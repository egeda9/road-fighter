using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLights : MonoBehaviour
{
    public GameObject RedLightOff;
    public GameObject RedLightOn;
    public GameObject AmberLightOff;
    public GameObject AmberLightOn;
    public GameObject GreenLightOff;
    public GameObject GreenLightOn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartingLightsTrigger());
    }

    IEnumerator StartingLightsTrigger()
    {
        yield return new WaitForSeconds(1f);
        RedLightOff.SetActive(false);
        RedLightOn.SetActive(true);
        yield return new WaitForSeconds(1f);
        RedLightOff.SetActive(true);
        RedLightOn.SetActive(false);
        AmberLightOff.SetActive(false);
        AmberLightOn.SetActive(true);
        yield return new WaitForSeconds(1f);
        AmberLightOff.SetActive(true);
        AmberLightOn.SetActive(false);
        GreenLightOff.SetActive(false);
        GreenLightOn.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SaveScript.RaceStart = true;
    }
}
