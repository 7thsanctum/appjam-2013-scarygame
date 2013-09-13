using UnityEngine;
using System.Collections;

public class PickUp: MonoBehaviour {
	
	public Light spotlight;
	private string message;
	private bool infoSwitch = false;
	private bool messageSwitch = false;
	private float gameTimer = 0.0f;
		
	void OnGUI()
	{
		//Center Screen Text
		GUI.Label(new Rect(Screen.width/2, Screen.height/2, 300.0f, 500.0f), message);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast(Camera.main.transform.position, fwd , out hit, spotlight.range))
		{
			if(hit.collider.tag == "FuelCan")
			{
				message = "Press 'R' To Pick Up";
				if (Input.GetKeyDown(KeyCode.R))
				{
					Destroy(hit.collider.gameObject);
					infoSwitch = true;
					messageSwitch = true;
				}
			}
			else if(hit.collider.tag == "Truck")
			{
				message = "Press 'R' To Pick Up";
				if (Input.GetKeyDown(KeyCode.R))
				{
					Destroy(hit.collider.gameObject);
					infoSwitch = true;
					messageSwitch = true;
				}
			}
			else { message = ""; }
		}
		
		if (infoSwitch == true) { message = "Youve Picked Up A Fuel Can"; }
		if (messageSwitch == true) { gameTimer += Time.deltaTime; }
		if (gameTimer >= 3.0f) { message = ""; }
	}
}