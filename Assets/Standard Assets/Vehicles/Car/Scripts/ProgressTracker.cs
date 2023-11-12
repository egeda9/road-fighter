using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    private AudioSource _player;
    private bool _isPlaying;
    public int CurrentWayPoint = 0;
    public int CurrentWayPointNumber;
    public int LastWayPointNumber;

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
                this._isPlaying = false;
        }
    }

    private void Update()
    {
        if (this.CurrentWayPoint > this.LastWayPointNumber)
            StartCoroutine(CheckDirection());

        if (this.LastWayPointNumber > this.CurrentWayPointNumber)
        {
            SaveScript.AddScore = true;
            SaveScript.ReduceScore = false;
            SaveScript.WrongWay = false;
        }

        if (this.LastWayPointNumber < this.CurrentWayPointNumber && SaveScript.Speed > 5)
        {
            SaveScript.AddScore = false;
            SaveScript.ReduceScore = true;
            SaveScript.WrongWay = true;
        }
    }

    IEnumerator CheckDirection()
    {
        yield return new WaitForSeconds(0.5f);
        this.CurrentWayPointNumber = this.LastWayPointNumber;
    }
}
