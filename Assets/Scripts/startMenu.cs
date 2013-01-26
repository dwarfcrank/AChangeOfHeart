using UnityEngine;
using System.Collections;

public class startMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () 
	{
		
				if (GUI.Button (new Rect (Screen.width/2-80,10, 170, 20), "Start")) 
				{
					Application.LoadLevel("testscene");
				}
			
				if (GUI.Button (new Rect (Screen.width/2-80,50, 170, 20), "Tutorial")) 
			    {
					Application.LoadLevel("testscene");
				}
				if (GUI.Button (new Rect (Screen.width/2-80,90, 170, 20), "Credits")) 
			    {
					Application.LoadLevel("testscene");
				}
				if (GUI.Button (new Rect (Screen.width/2-80,130, 170, 20), "Quit")) 
			    {
					Application.Quit();
				}
			
	}
}
