using UnityEngine;
using System.Collections;

public struct DistanceInformation
{
    public uint Address { get; set; }
    public float Distance { get; set; }

    public override string ToString()
    {
        return string.Format("Address = {0}; Distance = {1};", Address, Distance);
    }
}
