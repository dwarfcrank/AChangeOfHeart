using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	int laneNum = 2;
	float laneLocation;
	public float playerSpeed = 10.2f;
	public float minSpeed = 1.2f;
	public float maxSpeed = 24.0f;
	public float maxBPM = 90.0f;
	public MovingTexture road;
	public MicrophoneInput input;
	public static int screenArea;
	public Vector2 camPosition2D;
	public int score = 0;
	
	private int totalBeatsLastFrame;

	private float last_input;

	// Use this for initialization
	void Start () 
	{
		input = GameObject.Find("Beat Detector").GetComponent<MicrophoneInput>();
		totalBeatsLastFrame = input.totalBeats;
		last_input = Time.time;
	}
	
	public void SubtractScore(int num)
	{
		int newScore = score - num;
		
		score = Mathf.Max (newScore, 0);
	}
	
	public void AddScore(int num)
	{
		score += num;
	}
	
	// Update is called once per frame


	void Update () 
	{		
		if(totalBeatsLastFrame < input.totalBeats)
		{
			AddScore (input.totalBeats - totalBeatsLastFrame);
			totalBeatsLastFrame = input.totalBeats;
		}
		
		Vector3 newPosition = transform.position;
		camPosition2D = Camera.main.WorldToScreenPoint(newPosition);
		
		if(camPosition2D.x < (Screen.width/3)) {
			screenArea = 1;
		}
		else if((Screen.width*1/3) < camPosition2D.x && camPosition2D.x < (Screen.width*2/3)) {
			screenArea = 2;
		}
		else if(camPosition2D.x > (Screen.width*2/3)) {
			screenArea = 3;
		}
		
		// Changing lanes

		if(Time.time - last_input > 0.1)
		{
			if (Input.GetAxis("Vertical") > 0) 
			{
				if (laneNum > 1) 
				{
					laneNum--;
				}

				last_input = Time.time;
			} 
			else if (Input.GetAxis("Vertical") < 0)
			{
				if (laneNum < 3) 
				{
					laneNum++;
				}

				last_input = Time.time;
			} 
		}
		
		if (laneNum == 1) 
		{
			laneLocation = 0.9f;
		}
		else if (laneNum == 2) 
		{
			laneLocation = -0.3f;
		}
		else if (laneNum == 3) 
		{
			laneLocation = -1.45f;
		}
		newPosition.y = laneLocation;
		
		// Changing speed
		/*if (Input.GetKeyDown(KeyCode.A) && playerSpeed >= minSpeed) 
		{
			playerSpeed += -1.0f;
		}
		else if (Input.GetKeyDown(KeyCode.D) && playerSpeed < maxSpeed) 
		{
			playerSpeed += 1.0f;
		}*/
		
		float multiplier = (input.average_bpm / maxBPM);
		float targetSpeed = minSpeed + (maxSpeed - minSpeed) * multiplier;
		
		targetSpeed = Mathf.Min(maxSpeed, targetSpeed);

		if(targetSpeed > playerSpeed)
		{
			playerSpeed += (targetSpeed - playerSpeed) * Time.deltaTime * 2;
		}
		else if(targetSpeed < playerSpeed)
		{
			playerSpeed -= (playerSpeed - targetSpeed) * Time.deltaTime * 2;
		}
		
		playerSpeed = Mathf.Min(maxSpeed, playerSpeed);
	
		newPosition.x += playerSpeed * Time.deltaTime;
		
		// calculating movement to object
		transform.position = newPosition;
		
		road.OffsetSpeed = new Vector2(playerSpeed * Time.deltaTime * 0.001f, 0);
	}
}
