using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {
	
	public AudioClip clip;
	bool played = false;
	
	void Start()
	{
		this.audio.clip = clip;
	}
	
	//When the trigger is entered play a sound
	void OnTriggerEnter(Collider other)
	{
		if(!played)
		{
			if (other.tag == "Player")
			{
				audio.Play();
				played = true;
			}
		}
		
	}
	
}
