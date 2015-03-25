using UnityEngine;
using System.Collections;

public abstract class WheelSetup : MonoBehaviour
{
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;
    public Rigidbody body;
    public PhysicMaterial wheelMaterial;
    public float wheelMass = 1;
    public float wheelAirDrag = 0.5f;
    public float wheelRunDrag = 0.5f;
    public float wheelStopDrag = 50;
    public float maxRotationSpeed = 10;
    [Range(0, 1.0f)]
    public float torqueForceScale = 0.5f;

    private WheelInformation wheelConfigs;
    void Awake()
    {
        if (leftWheels.Length != rightWheels.Length)
            Debug.LogError("The number of left and right wheels must be the same!");

        wheelConfigs = new WheelInformation();
        wheelConfigs.Mass = wheelMass;
        wheelConfigs.AirDrag = wheelAirDrag;
        wheelConfigs.RunDrag = wheelRunDrag;
        wheelConfigs.StopDrag = wheelStopDrag;
        wheelConfigs.MaxRotationSpeed = maxRotationSpeed;
        wheelConfigs.TorqueForceScale = torqueForceScale;
        wheelConfigs.Material = wheelMaterial;

        for (int i = 0; i < leftWheels.Length; i++)
        {
            setupWheel(leftWheels[i], body, wheelConfigs);
            setupWheel(rightWheels[i], body, wheelConfigs);
        }
    }

    protected abstract void setupWheel(GameObject wheelTransform, Rigidbody handle, WheelInformation wheelConfigs);

    public WheelInformation getWheelInformation()
    {
        return wheelConfigs;
    }
}
