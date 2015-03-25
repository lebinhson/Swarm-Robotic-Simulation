using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LedController : MonoBehaviour 
{
    public GameObject[] ledPosition;

    public List<Behaviour> Leds { get; set; }

	void Awake () 
    {
        Leds = new List<Behaviour>();
        for (int i = 0; i < ledPosition.Length; i++)
        {
            //Due to limitations of Halo effect, we can only turn it on/off
            Leds.Add(ledPosition[i].GetComponent<Behaviour>());
        }
	}

    public void turnOn(int number)
    {
        checkNumberRange(number);
        Leds[number].enabled = true;
    }

    public void turnOff(int number)
    {
        checkNumberRange(number);
        Leds[number].enabled = false;
    }

    public void toggle(int number)
    {
        checkNumberRange(number);
        if (Leds[number].enabled)
            turnOff(number);
        else
            turnOn(number);
    }

    private void checkNumberRange(int number)
    {
        if (number < 0)
            throw new UnityException("Number must be larger than zero!");

        if (number >= Leds.Count)
            throw new UnityException(string.Format("Number must be smaller than {0}!", Leds.Count));
    }
}
