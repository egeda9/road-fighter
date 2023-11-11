using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    private AudioSource _player;
    private bool _isPlaying;
    public int CurrentWayPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        this._player = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            SaveScript.ReduceScore = true;
            if (this._isPlaying) 
                return;

            this._isPlaying = true;
            this._player.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SaveScript.ReduceScore = false;
        if (other.gameObject.CompareTag("Barrier"))
        {
            if (this._isPlaying)
            {
                this._isPlaying = false;
            }
        }
    }
}
