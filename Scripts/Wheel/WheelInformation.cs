using UnityEngine;
using System.Collections;

public class WheelInformation
{
    private float mass;
    private float airDrag;
    private float runDrag;
    private float stopDrag;
    private float maxRotationSpeed;
    private float torqueForceScale;
    private PhysicMaterial material;

    public float Mass 
    {
        get
        {
            checkValueInitialized(mass, "Mass");
            return mass;
        }
        set { mass = value; }
    }

    public float AirDrag
    {
        get
        {
            checkValueInitialized(airDrag, "Air Drag");
            return airDrag;
        }
        set { airDrag = value; }
    }

    public float RunDrag
    {
        get
        {
            checkValueInitialized(runDrag, "Run Drag");
            return runDrag;
        }
        set { runDrag = value; }
    }

    public float StopDrag
    {
        get
        {
            checkValueInitialized(stopDrag, "Stop Drag");
            return stopDrag;
        }
        set { stopDrag = value; }
    }

    public float MaxRotationSpeed
    {
        get
        {
            checkValueInitialized(maxRotationSpeed, "Max Rotation Speed");
            return maxRotationSpeed;
        }
        set { maxRotationSpeed = value; }
    }

    public float TorqueForceScale
    {
        get
        {
            checkValueInitialized(torqueForceScale, "Torque Force Scale");
            return torqueForceScale;
        }
        set { torqueForceScale = value; }
    }

    public PhysicMaterial Material
    {
        get
        {
            checkReferenceInitialized(material, "Material");
            return material;
        }
        set { material = value; }
    }

    private void checkValueInitialized(float value, string message)
    {
        if(value == 0)
            throwException(message);
    }

    private void checkReferenceInitialized(object obj, string message)
    {
        if (obj == null)
            throwException(message);
    }

    private void throwException(string message)
    {
        throw new UnityException(message + " is not initialized!");
    }
}
