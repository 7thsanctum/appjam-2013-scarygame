using UnityEngine;
using System.Collections;

public class AudioClips : MonoBehaviour {
	
	public AudioClip pig = null;
	public AudioClip background = null;
	public AudioClip background2 = null;
	public AudioClip heartBeat = null;
	public AudioClip ravens = null;
	public AudioClip hiss = null;
	
	public void playPig() { audio.PlayOneShot(pig); }
	public void playBackground() { audio.PlayOneShot(background); }
	public void playBackground2() { audio.PlayOneShot(background2); }
	public void playHeartBeat() { audio.PlayOneShot(heartBeat); }
	public void playRavens() { audio.PlayOneShot(ravens); }
	public void playHiss() { audio.PlayOneShot(hiss); }
}
