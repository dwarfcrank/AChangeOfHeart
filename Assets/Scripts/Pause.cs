using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	
	bool paused = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) || deathCollision.gameOver) 
		{
			if(!paused)
			{
				Time.timeScale = 0;
				paused = true;
			}
			else 
			{
				Time.timeScale = 1;
				paused = false;
			}
		}
	}
	void OnGUI () 
	{
		if(paused) {
			
			if (!deathCollision.gameOver) {
				if (GUI.Button (new Rect (Screen.width/2-80,10, 170, 20), "Resume")) 
				{
					Time.timeScale= 1;
					paused=false;
				}
			}
				if (GUI.Button (new Rect (Screen.width/2-80,50, 170, 20), "Restart")) 
			    {
					Time.timeScale= 1;
					paused=false;
					Application.LoadLevel(Application.loadedLevel);
				}
				if (GUI.Button (new Rect (Screen.width/2-80,90, 170, 20), "Quit")) 
			    {
					Application.Quit();
				}
			
		}
		
	}
}
