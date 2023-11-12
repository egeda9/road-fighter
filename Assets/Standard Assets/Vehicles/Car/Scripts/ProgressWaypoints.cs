using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressWaypoints : MonoBehaviour
{
    public int WayPointNumber;
    public int CarTracking;
    public bool PenaltyOption;
    public int PenaltyWayPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Progress"))
        {
            this.CarTracking = other.GetComponent<ProgressTracker>().CurrentWayPoint;

            if (this.CarTracking < this.WayPointNumber)
            {
                other.GetComponent<ProgressTracker>().CurrentWayPoint = this.WayPointNumber;
                //Debug.Log($"Current WayPoint = {other.GetComponent<ProgressTracker>().CurrentWayPoint}");
            }

            if (this.CarTracking > this.WayPointNumber)
                other.GetComponent<ProgressTracker>().LastWayPointNumber = this.WayPointNumber;

            if (this.PenaltyOption)
            {
                if (this.CarTracking < this.PenaltyWayPoint)
                {
                    Debug.Log("Penalty");
                }

            }
        }
    }
}
