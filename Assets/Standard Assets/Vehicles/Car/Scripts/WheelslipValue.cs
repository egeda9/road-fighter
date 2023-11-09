using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelslipValue : MonoBehaviour
{
    private WheelCollider _wheelCollider;
    public float RoadForwardStiffness = 3f;
    public float TerrainForwardStiffness = 0.6f;
    public float RoadSidewaysStiffness = 1.1f;
    public float TerrainSidewaysStiffness = 0.2f;
    public bool Changed;

    // Start is called before the first frame update
    void Start()
    {
        this._wheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.OnTheRoad)
        {
            if (!Changed)
            {
                this.Changed = true;
                var forwardFriction = this._wheelCollider.forwardFriction;
                forwardFriction.stiffness = this.RoadForwardStiffness;
                this._wheelCollider.forwardFriction = forwardFriction;

                var sidewaysFriction = this._wheelCollider.sidewaysFriction;
                sidewaysFriction.stiffness = this.RoadSidewaysStiffness;
                this._wheelCollider.sidewaysFriction = sidewaysFriction;
            }
        }

        if (SaveScript.OnTheTerrain)
        {
            if (Changed)
            {
                this.Changed = false;
                var forwardFriction = this._wheelCollider.forwardFriction;
                forwardFriction.stiffness = this.TerrainForwardStiffness;
                this._wheelCollider.forwardFriction = forwardFriction;

                var sidewaysFriction = this._wheelCollider.sidewaysFriction;
                sidewaysFriction.stiffness = this.TerrainSidewaysStiffness;
                this._wheelCollider.sidewaysFriction = sidewaysFriction;
            }
        }
    }
}
