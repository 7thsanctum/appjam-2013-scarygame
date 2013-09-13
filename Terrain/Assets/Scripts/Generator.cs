using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {
	
	public float fuelLevel = 0.0f;
	public bool lightsOn = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fuelLevel > 0.0f)
		{
			fuelLevel -= 0.1f;
			lightsOn = true;
			switchLight();
		}
		else 
		{
			lightsOn = false;	
			switchLight();
		}	
	}
	
	void addFuel(float fuel)
	{
		fuelLevel += fuel;	
	}
	
	void switchLight()
	{
		if(lightsOn)
		{
			Light light = GetComponentInChildren<Light>();	
			light.enabled = true;
		}
		else 
		{
			Light light = GetComponentInChildren<Light>();	
			light.enabled = false;
			
			//TODO enable disable audio queues
		}	
	}
}
