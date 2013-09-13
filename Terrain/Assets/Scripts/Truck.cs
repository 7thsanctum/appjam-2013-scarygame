using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour {
	
	public float fuelLevel = 0.0f;
	public ConeTrigger trig;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fuelLevel > 500.0f)
		{
			trig.SendMessage("fuelFull");
		}
		print (fuelLevel);
	}
	
	void addFuel(float fuel)
	{
		fuelLevel += fuel;	
	}
	

}
