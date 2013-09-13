using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject[] positionList;
	
	public GUIStyle titleStyle;
	public GUIStyle buttonStyle;
	bool isLoading = false;
	bool howTo = false;
	private string walk = "Start";
	private string jump = "How to Play";
	private string charge = "Quit";
	private string exit = "";
	void OnGUI () {
		
    	GUI.Label (new Rect ((Screen.width/2) - 50, (25), 100, 50), "Silent Night", titleStyle);
		
		if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2)-30, 125, 75), walk, buttonStyle)) 
		{		
			isLoading = true;
			Application.LoadLevel("Scene 1");
			
		}
		if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2)+25, 125, 75), jump, buttonStyle)) 
		{		
			howTo = true;
			
		}
		if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2)+135, 125, 75), exit, buttonStyle)) 
		{		
			howTo = false;
			
		}
		var isWebPlayer = (Application.platform == RuntimePlatform.OSXWebPlayer ||
		Application.platform == RuntimePlatform.WindowsWebPlayer);
		if (!isWebPlayer)
		{		
			if (GUI.Button (new Rect ((Screen.width/2), (Screen.height/2)+80, 125, 75), charge, buttonStyle)) {
				Application.Quit();
			}
		}
		
		if (isLoading)
			GUI.Label ( new Rect( (Screen.width/2)-110, (Screen.height / 2) - 60, 400, 70),
						"Loading...",titleStyle);
		
		if(howTo)
		{
			walk = "WASD to walk";
			jump = "Space to jump";
			charge = "Tap F to recharge torch";
			exit = "Exit";
		}
		
		if(!howTo)
		{
			 walk = "Start";
			 jump = "How to Play";
			 charge = "Quit";
			 exit = "";
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
