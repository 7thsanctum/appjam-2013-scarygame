using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	public GameObject[] positionList;
	
	public GUIStyle titleStyle;
	public GUIStyle buttonStyle;
	bool isLoading = false;
	public bool isVictory = false;
	void OnGUI () {
		if(!isVictory)
		{
	    	GUI.Label (new Rect ((Screen.width/2) - 50, (25), 100, 50), "Game Over", titleStyle);
			
			if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2)-25, 125, 75), "Restart", buttonStyle)) 
			{		
				isLoading = true;
				Application.LoadLevel("Scene 1");
				
			}
			var isWebPlayer = (Application.platform == RuntimePlatform.OSXWebPlayer ||
			Application.platform == RuntimePlatform.WindowsWebPlayer);
			if (!isWebPlayer)
			{		
				if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2)+75, 125, 75), "Quit", buttonStyle)) {
					Application.Quit();
				}
			}
			
			if (isLoading)
				GUI.Label ( new Rect( (Screen.width/2)-110, (Screen.height / 2) - 60, 400, 70),
							"Loading...",titleStyle);
		}
		else
		{
			GUI.Label (new Rect ((Screen.width/2) - 50, (25), 100, 50), "Victory", titleStyle);
			
			if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2)-25, 125, 75), "Restart", buttonStyle)) 
			{		
				isLoading = true;
				Application.LoadLevel("Scene 1");
				
			}
			var isWebPlayer = (Application.platform == RuntimePlatform.OSXWebPlayer ||
			Application.platform == RuntimePlatform.WindowsWebPlayer);
			if (!isWebPlayer)
			{		
				if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2)+75, 125, 75), "Quit", buttonStyle)) {
					Application.Quit();
				}
			}
			
			if (isLoading)
				GUI.Label ( new Rect( (Screen.width/2)-110, (Screen.height / 2) - 60, 400, 70),
							"Loading...",titleStyle);
		}
	}
	
	// Use this for initialization
	void Start () {
		int rand = (int)Random.Range(0.0F, 2.0F);
		Camera.main.transform.position = positionList[rand].transform.position;
		Camera.main.transform.rotation = positionList[rand].transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
