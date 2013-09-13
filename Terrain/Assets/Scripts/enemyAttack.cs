//enemyAttack will be attached to an enemy game object (not the player)
using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {
	
	//Public Variables
	public GameObject player = null;	
	public float attackSpeed = 2.0f;
	public float attackRadius = 500.0f;
	public float rotationSpeed = 5.0f;
	public AudioClip clip = null;
	public bool freeze = false;
	public bool roamer = false;
	//Private Variables
	private float gameTimer = 0.0f;
	
	//Enemy Freeze
	public void enemyFreeze(bool freezeOn)
	{
		freeze = freezeOn;
	}
	
	//Enemy Invisiable
	void enemyInvisible(float timeoff, float timeon)
	{
		//Increase Game Timer
		gameTimer++;
		
		if (freeze == false && gameTimer > timeoff)
		{
			renderer.enabled = false;
			gameTimer = 0.0f;
		}
		else if (freeze == false && gameTimer > timeon)
		{
			renderer.enabled = true;
			gameTimer = 0.0f;			
		}
		
		if (freeze == true && gameTimer > timeon)
		{
			enemyFreeze(false);
			gameTimer = 0.0f;
			renderer.enabled = true;
		}
		else if (freeze == true && gameTimer > timeoff)
		{
			renderer.enabled = false;
			//gameTimer = 0.0f;
		}
	}
	
	//Update
	void Update () {
		if(roamer)
		{
			//Draw line between enemy and player
		Debug.DrawLine(player.transform.position, transform.position, Color.black);
		
		if (freeze == false)
		{	
			//Radius
			if ((player.transform.position.x > transform.position.x - attackRadius) && (player.transform.position.x < transform.position.x + attackRadius))
			{
				//Rotate from (point a, to point b, at what speed)
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - player.transform.position), rotationSpeed * Time.deltaTime);
		
				//Enemy movement
				transform.position -= transform.forward * attackSpeed * Time.deltaTime;
			}
			//Call enemyInvisiable
			enemyInvisible(100.0f, 50.0f);
		}
		else 
		{
			enemyInvisible(30.0f, 200.0f);
			transform.position = new Vector3( player.transform.position.x + 20.0f, transform.position.y, player.transform.position.z - 20.0f );
		}
		
		Vector3 playerDistance = player.transform.position - transform.position;
		
		if (playerDistance.z <= 5.0f && playerDistance.x <= 5.0f){ 
			//Scale Enemy
			transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
			if (transform.localScale.x > 3.0f && transform.localScale.y > 3.0f && transform.localScale.z > 3.0f) { transform.localScale = new Vector3(3.0f, 3.0f, 3.0f); }
			
			//Play Heart Beat
			Camera.main.GetComponent<AudioClips>().playPig();
		}
		else { transform.localScale = new Vector3(1,1,1); }
		}
		
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			Application.LoadLevel("Game Over");
		}
	}
}