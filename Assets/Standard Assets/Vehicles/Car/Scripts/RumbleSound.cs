using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleSound : MonoBehaviour
{
    private AudioSource _player;

    // Start is called before the first frame update
    void Start()
    {
        this._player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.Rumble1 || SaveScript.Rumble2)
            this._player.Play();
        else
            this._player.Stop();
    }
}
