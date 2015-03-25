using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class RFTransceiver<T> : MonoBehaviour, IAddress 
{
    private uint address;
    public uint Address { get { return address; } }

    private List<RFTransceiver<T>> others;

    public delegate void communication(RFPacket<T> packet);
    public event communication receivedDataEvent;

	void Start () 
    {
	    others = new List<RFTransceiver<T>>();
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "RFReceiver")
            others.Add(other.GetComponentInParent<RFTransceiver<T>>());
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "RFReceiver")
            others.Remove(other.GetComponentInParent<RFTransceiver<T>>());
    }

    public void setAddress(uint address)
    {
        this.address = address;
    }

    public void receivedData(RFPacket<T> packet)
    {
        receivedDataEvent(packet);
    }

    public virtual void transmit(uint destination, T[] data)
    {
        for (int i = 0; i < others.Count; i++)
        {
            if (others[i].address == destination)
            {
                RFPacket<T> packet = setupPacket(data);
                others[i].receivedData(packet);
                return;
            }
        }
        Debug.Log(string.Format("Can't send RF data from {0} to {1}", this.address, destination));
    }

    public virtual void broadcast(T[] data)
    {
        if (others.Count == 0)
            return;

        RFPacket<T> packet = setupPacket(data);
        for (int i = 0; i < others.Count; i++)
        {
            others[i].receivedData(packet);
        }
    }

    private RFPacket<T> setupPacket(T[] data)
    {
        RFPacket<T> packet = new RFPacket<T>();
        packet.data = data;
        packet.Address = this.address;
        return packet;
    }
}
