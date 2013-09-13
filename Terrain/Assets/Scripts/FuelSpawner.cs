using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FuelSpawner : MonoBehaviour {
	
	public List<GameObject> spawnPointList;
	
	// Use this for initialization
	void Start () {
		foreach(Transform childChild in this.gameObject.transform)
		{			
			foreach(Transform childChildChild in childChild)
			{
				foreach(Transform child in childChildChild)
				{
					if(child.gameObject.tag == "fuelspawners")
					{
						foreach(Transform children in child)
						{
							if(children.gameObject.tag == "fuelspawn")
							{
								Debug.Log ("Found Fuel Spawner !");
								spawnPointList.Add(child.gameObject);	
							}
						}
					}
					if(child.gameObject.tag == "fuelspawn")
					{
						Debug.Log ("Found Fuel Spawner !");
						spawnPointList.Add(child.gameObject);	
					}
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
