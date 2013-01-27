using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	
	private bool paused = false;
	bool dead = false;
	public GUISkin PointSkin;
	public Texture2D background;
	public GUISkin PointSkin2;
	public GUISkin PointSkin3;
	bool endlevel=false;
	// Use this for initialization
	void Start () {
		Time.timeScale=1;
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)&& !deathCollision.gameOver) 
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
		//GUI.matrix =Matrix4x4.TRS (new Vector3(0, 0, 0),Quaternion.Euler(0,0,0),new Vector3 (rx, ry, 1)); 
		
		if (paused) {
			GUI.skin = PointSkin2;
		}
		else if (deathCollision.gameOver) {
			GUI.skin = PointSkin3;
		}
		
		if(paused || deathCollision.gameOver)
		{
			Time.timeScale = 0; // testing stop time on pause

			GUI.Box(new Rect(0,0,Screen.width,Screen.height),"");
			if(!deathCollision.gameOver)
			{
				if (GUI.Button (new Rect (Screen.width/2-100,Screen.height*12/22-15, 200, 40), "")) // RESUME
		        {
					Time.timeScale= 1;
					paused=false;
				}
			}
			else {
				GUI.Label (new Rect (Screen.width/2-100,Screen.height*12/22-15, 200, 40), 
					string.Format("Score: {0}", GameObject.Find ("ScoreText").GetComponent<ScoreText>().score));
				} // SCORE
		        
			if (GUI.Button (new Rect (Screen.width/2-100, Screen.height*15/22-15, 200, 40), "")) // Restart
			        {
						Application.LoadLevel(Application.loadedLevel);
						
					}
			if(GUI.Button (new Rect (Screen.width/2-100,Screen.height*4/5-15, 200, 40), "")) // Quit
			{
				Application.Quit();
			}
			
		}
	}
}
