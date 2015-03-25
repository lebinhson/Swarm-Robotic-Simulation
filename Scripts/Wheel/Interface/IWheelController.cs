using UnityEngine;
using System.Collections;

public interface IWheelController 
{
    void runForward();

    void runBackward();

    void turnLeft();

    void turnRight();

    void stopApplyingForce();

    void updateDrag();
}
