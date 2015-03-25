using UnityEngine;
using System.Collections;

public class TBotWheelSetup : WheelSetup
{
    protected override void setupWheel(GameObject wheelTransform, Rigidbody handle, WheelInformation wheelConfigs)
    {
        handle.position = Vector3.zero;

        Rigidbody body = wheelTransform.AddComponent<Rigidbody>();
        body.mass = wheelConfigs.Mass;
        body.angularDrag = wheelConfigs.RunDrag;
        body.drag = wheelConfigs.AirDrag;
        body.maxAngularVelocity = wheelConfigs.MaxRotationSpeed;

        SphereCollider collider = wheelTransform.AddComponent<SphereCollider>();
        collider.material = wheelConfigs.Material;

        wheelTransform.AddComponent<ConstantForce>();

        ConfigurableJoint joint = wheelTransform.AddComponent<ConfigurableJoint>();
        joint.connectedBody = handle;
        joint.anchor = Vector3.zero;
        joint.angularXMotion = ConfigurableJointMotion.Free;
        joint.angularYMotion = ConfigurableJointMotion.Locked;
        joint.angularZMotion = ConfigurableJointMotion.Locked;
        joint.xMotion = ConfigurableJointMotion.Locked;
        joint.yMotion = ConfigurableJointMotion.Locked;
        joint.zMotion = ConfigurableJointMotion.Locked;
        joint.axis = Vector3.zero;
        joint.secondaryAxis = Vector3.zero;
        joint.autoConfigureConnectedAnchor = false;
        Vector3 pos = wheelTransform.transform.localPosition;
        joint.connectedAnchor.Set(pos.x, pos.y, pos.z);
    }
}
