using UnityEngine;
using System.Collections;

public class TBotUserDrive : MonoBehaviour 
{
    public WheelSetup wheelSetupScript;
    public LedController ledScript;
    public RFTransceiverByte rfBoard;
    public DistanceSensing distanceSensor;

    public uint address;

    private IWheelController wheelController;

    void Start()
    {
        wheelController = new DifferntialWheelController(wheelSetupScript.leftWheels, wheelSetupScript.rightWheels, 
                                                                            wheelSetupScript.getWheelInformation());
        rfBoard.receivedDataEvent += printRFPacket;
        rfBoard.setAddress(address);
        distanceSensor.setAddress(address);
    }
 
	void FixedUpdate () 
    {
        getMotorControlInput();
        wheelController.updateDrag();
	}

    private void getMotorControlInput()
    {   
        if (Input.GetKey(KeyCode.UpArrow))
        {
            wheelController.runForward();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            wheelController.runBackward();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            wheelController.turnLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            wheelController.turnRight();
        }

        if (Input.GetKey(KeyCode.S))
        {
            wheelController.stopApplyingForce();
        }  
    }

    void Update()
    {
        getLedControlInput();
    }

    private void getLedControlInput()
    {
        if (Input.GetKeyUp(KeyCode.Keypad1))
        {
            ledScript.toggle(0);
        }

        if (Input.GetKeyUp(KeyCode.Keypad2))
        {
            ledScript.toggle(1);
        }

        if (Input.GetKeyUp(KeyCode.Keypad3))
        {
            ledScript.toggle(2);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            testTransmitRF();
        }

        if (Input.GetKeyUp(KeyCode.B))
        {
            testBroadcastRF();
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            distanceSensor.updateDistanceAllNeighbor();
        }
    }

    private void testTransmitRF()
    {
        byte[] data = initTestDataRF();
        rfBoard.transmit(0x5050, data);
    }

    private void testBroadcastRF()
    {
        byte[] data = initTestDataRF();
        rfBoard.broadcast(data);
    }

    private byte[] initTestDataRF()
    {
        byte[] data = new byte[32];
        for (byte i = 0; i < data.Length; i++)
        {
            data[i] = i;
        }
        return data;
    }

    private void printRFPacket(RFPacket<byte> packet)
    {
        Debug.Log(packet.Address);
        for (int i = 0; i < packet.data.Length; i++)
        {
            Debug.Log(packet.data[i]);
        }
    }
}
