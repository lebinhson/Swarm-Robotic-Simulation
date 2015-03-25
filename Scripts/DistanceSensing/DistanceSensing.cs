using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DistanceSensing : MonoBehaviour, IAddress
{
    public bool isRandomNoiseEnable = false;
    public float noiseRange = 0.15f;

    public List<DistanceInformation> Neighbors { get; set; }
    private List<Collider> others;

    private uint address;
    public uint Address { get { return address; } }


    void Start()
    {
        Neighbors = new List<DistanceInformation>();
        others = new List<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        this.others.Add(other);
    }

    void OnTriggerExit(Collider other)
    {
        this.others.Remove(other);
    }

    public void setAddress(uint address)
    {
        this.address = address;
    }

    public void updateDistanceAllNeighbor()
    {
        Neighbors.Clear();
        DistanceInformation newNeighbor = new DistanceInformation();
        for (int i = 0; i < others.Count; i++)
        {
            newNeighbor.Distance = calculateDistance(others[i].transform);
            newNeighbor.Address = others[i].GetComponentInChildren<IAddress>().Address;
            Neighbors.Add(newNeighbor);
        }
    }

    private float calculateDistance(Transform neighbor)
    {
        float distance = Vector3.Distance(neighbor.position, transform.position);
        if (isRandomNoiseEnable)
            distance = distance + Random.Range(-noiseRange, noiseRange);
        return distance;
    }
}
