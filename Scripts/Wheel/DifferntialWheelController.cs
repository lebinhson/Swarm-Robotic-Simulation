using UnityEngine;
using System.Collections;

public class DifferntialWheelController : IWheelController
{
    private GameObject[] leftWheels;
    private GameObject[] rightWheels;
    private WheelInformation wheelConfigs;

    public DifferntialWheelController(GameObject[] leftWheels, GameObject[] rightWheels, WheelInformation wheelConfigs)
    {
        if (leftWheels.Length != rightWheels.Length)
            Debug.LogError("The number of left and right wheels must be the same!");

        this.leftWheels = leftWheels;
        this.rightWheels = rightWheels;
        this.wheelConfigs = wheelConfigs;
    }

    public void runForward()
    {
        for (int i = 0; i < leftWheels.Length; i++)
        {
            leftWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.right * wheelConfigs.TorqueForceScale;
            rightWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.left * wheelConfigs.TorqueForceScale;
        }
    }

    public void runBackward()
    {
        for (int i = 0; i < leftWheels.Length; i++)
        {
            leftWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.left * wheelConfigs.TorqueForceScale;
            rightWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.right * wheelConfigs.TorqueForceScale;
        }
    }

    public void turnLeft()
    {
        for (int i = 0; i < leftWheels.Length; i++)
        {
            leftWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.left * wheelConfigs.TorqueForceScale;
            rightWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.left * wheelConfigs.TorqueForceScale;
        }
    }

    public void turnRight()
    {
        for (int i = 0; i < leftWheels.Length; i++)
        {
            leftWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.right * wheelConfigs.TorqueForceScale;
            rightWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.right * wheelConfigs.TorqueForceScale;
        }
    }

    public void stopApplyingForce()
    {
        for (int i = 0; i < leftWheels.Length; i++)
        {
            leftWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.zero;
            rightWheels[i].GetComponent<ConstantForce>().relativeTorque = Vector3.zero;
        }
    }

    public void updateDrag()
    {
        for (int i = 0; i < leftWheels.Length; i++)
        {
            calculateDrag(leftWheels[i]);
            calculateDrag(rightWheels[i]);
        }
    }

    private void calculateDrag(GameObject wheel)
    {
        if (wheel.GetComponent<ConstantForce>().relativeTorque == Vector3.zero)
        {
            wheel.GetComponent<Rigidbody>().angularDrag = wheelConfigs.StopDrag;
        }
        else
        {
            wheel.GetComponent<Rigidbody>().angularDrag = wheelConfigs.RunDrag;
        }
    }
}
