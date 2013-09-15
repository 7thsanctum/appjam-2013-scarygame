using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * This fuelspawner class is to be in charge of how many fuel cans spawn, where they spawn etc 
 * there will be a random amount spawned and they are more likely to spawn based upon distance 
 * from the player etc 
 * perhaps an additional feature will be if a player gets within a certain distance or sees a location in which fuel
 * may spawn but there is none, that spawn point will become deactivated preventing fuel cans from spawning in places the player has been.
 * 
 */

public class FuelSpawner : MonoBehaviour 
{
	public GameObject fuelPrefab;
	
	private List<GameObject> spawnPointList;
	
	void Start () 
	{
		spawnPointList = GameObject.FindGameObjectsWithTag("fuelspawn").OfType<GameObject>().ToList();		
		
		foreach( GameObject spawn in spawnPointList )
		{
			GameObject can = Instantiate(fuelPrefab, spawn.transform.position, spawn.transform.rotation) as GameObject;
			can.transform.parent = spawn.transform;
		}
	}
	
	void Update () 
	{
	
	}
}
