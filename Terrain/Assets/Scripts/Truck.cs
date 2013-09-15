using UnityEngine;
using System.Collections;

public class Truck : MonoBehaviour 
{	
	//TODO change this so that it works in relation to a central game manager class
	// thus sending the message to that rather than the players cone
	
	public float fuelLevel = 0.0f;
	public ConeTrigger trig;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void addFuel(float fuel)
	{
		fuelLevel += fuel;	
		if(fuelLevel > 500.0f)
		{
			trig.SendMessage("fuelFull");
		}
	}
	

}
