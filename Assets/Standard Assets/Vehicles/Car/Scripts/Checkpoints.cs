using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public bool CheckPoint1 = true;
    public bool CheckPoint2;

    private void OnTriggerEnter(Component other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (CheckPoint1)
            {
                SaveScript.ThisCheckPoint1 = SaveScript.GameTime;
                SaveScript.CheckpointPass1 = true;
            }

            if (CheckPoint2)
            {
                SaveScript.ThisCheckPoint2 = SaveScript.GameTime;
                SaveScript.CheckpointPass2 = true;
            }
        }
    }
}
