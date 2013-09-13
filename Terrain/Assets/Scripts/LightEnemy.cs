using UnityEngine;
using System.Collections;

public class LightEnemy : MonoBehaviour {
		
	Light spot;
	
	void Start()
	{
		spot = GetComponentInChildren<Light>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "enemy" && spot.enabled == true)
		{
			print ("Entered Light");
			SphereCollider col = (SphereCollider)this.collider;
			float zPos = other.transform.position.z + col.radius / col.radius;
			float xPos = other.transform.position.x + col.radius / col.radius;
			
			Vector3 position = new Vector3(xPos, transform.position.y, zPos);
			
			other.transform.position = position;
		}
	}
}
 