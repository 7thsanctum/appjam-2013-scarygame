using UnityEngine;
using System.Collections;

public class LightDestroyer : MonoBehaviour {
	
	private Light spotlight;
	float radius;
	// Use this for initialization
	void Start () {
		spotlight = GetComponent<Light>();
	}
		
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast(transform.position, fwd , out hit, spotlight.range))
		{
			if(hit.collider.tag == "Enemy")
			{
				//Debug.DrawRay(transform.position, fwd * 10.0f, Color.red, 20);
				//print ("You killed the enemy!!!!!!");
				//hit.collider.gameObject.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
			}
		}
		
		
		
        
            
	}
}
