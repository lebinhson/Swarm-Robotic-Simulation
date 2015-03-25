using UnityEngine;
using System.Collections;

public struct RFPacket<T>
{
    private uint address;

    public T[] data { get; set; }

    public uint Address
    {
        get
        {
            checkValueInitialized(address, "Address");
            return address;
        }
        set { address = value; }
    }


    private void checkValueInitialized(float value, string message)
    {
        if (value == 0)
            throwException(message);
    }

    private void throwException(string message)
    {
        throw new UnityException(message);
    }

    public override string ToString()
    {
        return address.ToString();
    }
}
