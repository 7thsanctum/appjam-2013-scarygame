using UnityEngine;
using System.Collections;

public class StaticEnemy : MonoBehaviour {
	
	bool attack = false;
	public GameObject player = null;
	public float rotationSpeed = 5.0f;
	public float attackSpeed = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(attack)
		{
			//Rotate from (point a, to point b, at what speed)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - player.transform.position), rotationSpeed * Time.deltaTime);
	
			//Enemy movement
			transform.position -= transform.forward * attackSpeed * Time.deltaTime;
		}
	}
	
	void OnTriggerEnter()
	{
		attack = true;
	}
	
	void OnTriggerExit()
	{
		attack = false;
	}
}
