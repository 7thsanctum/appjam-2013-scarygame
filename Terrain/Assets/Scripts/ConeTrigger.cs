using UnityEngine;
using System.Collections;

public class ConeTrigger : MonoBehaviour {
	
	public Light light = null;
	public float lightDarken = 200.0f;
	
	private float chargeDelay = 25.0f;
	private float chargeTimer = 0.0f;
	public string message;
	private bool infoSwitch = false;
	private bool messageSwitch = false;
	private float messageTimer = 0.0f;
	private float gameTimer = 0.0f;
	private bool lightState = true;
	private bool truckFull = false;
	private float batteryLife = 0.0f;
	//private float fuelLevels = 0.35f;
	private float fuelCans = 0;
	
	// Use this for initialization
	void Start () {
		light.enabled = true;
		truckFull = false;
	}
	
	void OnGUI()
	{
		//Output Battery Text
		GUI.Label(new Rect(10.0f, 1.0f, 100.0f, 30.0f), "Battery Life: ");
		
		//Output Fuel Text
		GUI.Label(new Rect(10.0f, Screen.height - 60.0f, 100.0f, 30.0f), "Fuel: " + fuelCans + "CL");
		
		//Output Battery Levels
		GUI.Button(new Rect(10.0f, 20.0f, batteryLife * 20.0f, 30.0f), "");	
		
		//Output Fuel Levels
		GUI.Button(new Rect(10.0f, Screen.height - 40.0f, fuelCans * 0.4f, 30.0f), "");
		
		//Center Screen Text
		GUI.Label(new Rect(Screen.width/2, Screen.height/2, 300.0f, 500.0f), message);
	}
	
	// Update is called once per frame
	void Update () {
		renderer.enabled = false;
		Screen.showCursor = false;
		
		//Set Battery Life
		batteryLife = light.intensity;
		chargeTimer += Time.deltaTime;
		//User Input
        if (Input.GetKeyDown(KeyCode.F))
		{
			if(chargeTimer > 0.6f)
			{
				batteryLife += 0.3f;
				light.intensity += 0.3f;
				chargeTimer = 0.0f;
			}
		}
		
		if (Input.GetKeyDown(KeyCode.E))
		{
        	lightState = !lightState;
            light.enabled = lightState;
		}
		
		//Increase Game Timer
		gameTimer += Time.deltaTime;
		
		//Decrease light intensity
		if (gameTimer > 3.5f && lightState == true) { 
			batteryLife -= 0.4f;
			light.intensity -= 0.4f;
			gameTimer = 0.0f;
		}
		
		light.intensity = batteryLife;
		
		//Fire a ray from the cone outward and check what it collides with
		Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, fwd , out hit, light.range))
		{
			if(hit.collider.tag == "FuelCan")
			{
				message = "Press 'R' To Pick Up";
				if (Input.GetKeyDown(KeyCode.R))
				{
					Destroy(hit.collider.gameObject);
					infoSwitch = true;
					messageSwitch = true;
					fuelCans += Random.Range(50.0f, 150.0f);
				}
			}
			else { message = ""; }
			
			if(hit.collider.tag == "Generator")
			{
				message = "Press 'R' To Deposit Fuel";
				if (Input.GetKeyDown(KeyCode.R))
				{
					hit.collider.gameObject.SendMessage("addFuel", fuelCans);
					infoSwitch = false;
					messageSwitch = true;
					fuelCans = 0;
				}
			}
			print (truckFull);
			if(truckFull == false)
			{
				print ("Truck not full");
				if(hit.collider.tag == "Truck")
				{
					message = "Press 'R' To Deposit Fuel";
					if (Input.GetKeyDown(KeyCode.R))
					{
						hit.collider.gameObject.SendMessage("addFuel", fuelCans);
						infoSwitch = false;
						messageSwitch = true;
						fuelCans = 0;
					}
				}
			}
			else
			{
				if(hit.collider.tag == "Truck")
				{
					message = "Press 'F' To Escape";
					if (Input.GetKeyDown(KeyCode.F))
					{
						Application.LoadLevel("Victory");
					}
				}	
			}
		}
		
		if (infoSwitch == true) { message = "Youve Picked Up A Fuel Can"; }
		if (messageSwitch == true) { messageTimer += Time.deltaTime; }
		if (gameTimer >= 3.0f) { message = ""; infoSwitch = false; }
	}
	
	void OnTriggerStay(Collider other)
	{
		if (light.enabled == true)
		{
			print ("Trigger is entered");
			if(other.tag == "enemy")
			{	
				other.GetComponent<enemyAttack>().enemyFreeze(true);
			}
		}
	}
	
	void fuelFull()
	{
		truckFull = true;
	}
}
