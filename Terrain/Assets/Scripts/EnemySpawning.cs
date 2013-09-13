using UnityEngine;
using System.Collections;

public class EnemySpawning : MonoBehaviour {

	//Public Variables
	public float batteryLife = 10.0f;
	public float enemySpawn = 100.0f;
	public GameObject player = null;
	//Private Variables
	private float batteryLimit = 0.0f;
	private float enemyVisibleCounter = 0.0f;
	
	void Start () { }//renderer.enabled = false; }  //Invisible To Start 
	
	void OnGUI()
	{
		GUI.Button(new Rect(10.0f, 10.0f, batteryLife * 10.0f, 30.0f), "Battery Life");
	}
	
	void seek()
	{
		Vector3 enemyDistance = player.transform.position - transform.position;
		
		if (enemyDistance.z > 1)
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
	}
	
	void Update () {
		batteryLimit++; //Increase Game Timer
		enemyVisibleCounter++;  //Increase Enemy Visible Counter
		/*if (enemyVisibleCounter > enemySpawn){ 
			renderer.enabled = true;  //Make Gameobject Visible 
			if (enemyVisibleCounter > enemySpawn + 5.0f){ renderer.enabled = false; }  //Make Gameobject Invisible
			if (enemyVisibleCounter > enemySpawn + 15.0f){ 
				transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - 2.0f);  //Reoposition
				renderer.enabled = true;  //Make Gameobject Visible
			}
			if (enemyVisibleCounter > enemySpawn + 20.0f) { renderer.enabled = false; }
			if (enemyVisibleCounter > enemySpawn + 30.0f){ 
				transform.position = new Vector3(player.transform.position.x - 2.0f, transform.position.y, transform.position.z); ;  //Reoposition
				renderer.enabled = true;  //Make Gameobject Visible
			}
			if (enemyVisibleCounter > enemySpawn + 35.0f) { renderer.enabled = false; }
			if (enemyVisibleCounter > enemySpawn + 45.0f){ 
				transform.position = new Vector3(player.transform.position.x + 2.0f, transform.position.y, transform.position.z);;  //Reoposition
				renderer.enabled = true;  //Make Gameobject Visible
			}
			if (enemyVisibleCounter > enemySpawn + 50.0f) { renderer.enabled = false; }
			if (enemyVisibleCounter > enemySpawn + 60.0f){ 
				transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z + 2.0f); ;  //Reoposition
				renderer.enabled = true;  //Make Gameobject Visible
				enemyVisibleCounter = 0.0f;  //Reset Game Timer
			}
		}*/
		
		seek();
		
		//Battery Life
		if (batteryLimit > 100.0f) {
			batteryLife -= 1;     //Decrease Battery Life
			batteryLimit = 0.0f;  //Reset Battery Limit
			
			if(batteryLife < 1) { batteryLife = 1; }  //Stop Battery Going Into Minus
		}
	}
}
