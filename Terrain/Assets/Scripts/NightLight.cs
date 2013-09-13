using UnityEngine;
using System.Collections;

public class NightLight : MonoBehaviour
{
//    public Light light;
//	public float lightDarken = 500.0f;
//	public float gameTimer = 0.0f;
//	private bool lightState = true;
//	private float batteryLife = 0.0f;
//	public GameObject cone = null;
//
//    void Start()
//	{
//		light.enabled = true;
//		cone.collider.enabled = false;
//	}
//	
//	void OnGUI()
//	{
//		//Output GUI Text
//		GUI.Label(new Rect(10.0f, 1.0f, 100.0f, 30.0f), "Battery Life: ");
//		
//		//Output Light Battery
//		GUI.Button(new Rect(10.0f, 20.0f, batteryLife * 20.0f, 30.0f), "");
//	}
//	
//	// Update is called once per frame
//	void Update ()
//	{
//		//Set Battery Life
//		batteryLife = light.intensity;
//		
//		//User Input
//        if (Input.GetKeyDown(KeyCode.E))
//		{
//        	lightState = !lightState;
//            light.enabled = lightState;
//			//cone.collider.enabled = lightState;
//			cone.collider.isTrigger = lightState;
//        }
//		
//		//Increase Game Timer
//		gameTimer++;
//		
//		//Decrease light intensity
//		if (gameTimer > lightDarken && lightState == true) { 
//			batteryLife -= 0.2f; 
//			gameTimer = 0.0f;
//		}
//		
//		//No Battery Life
//		if (batteryLife <= 0) {
//			cone.collider.enabled = lightState;
//			cone.collider.isTrigger = lightState;
//		}
//		
//		light.intensity = batteryLife;
//	}
}
