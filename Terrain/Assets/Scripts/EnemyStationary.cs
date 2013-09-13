using UnityEngine;
using System.Collections;

public class EnemyStationary : MonoBehaviour {
	bool enabled = false;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(enabled)
		{
			this.transform.LookAt(Camera.main.transform);	
		}
	}
	
	void OnBecameVisible() {
		Debug.Log("Became Visible");
        enabled = true;
    }	
}
