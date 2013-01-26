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

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPosition = transform.position;
		
		// Changing lanes
		if (Input.GetKeyDown(KeyCode.W)) 
		{
			if (laneNum > 1) 
			{
				laneNum--;
			}
		} 
		else if (Input.GetKeyDown(KeyCode.S)) 
		{
			if (laneNum < 3) 
			{
				laneNum++;
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
		if (Input.GetKeyDown(KeyCode.A) && playerSpeed >= minSpeed) 
		{
			playerSpeed += -1.0f;
		}
		else if (Input.GetKeyDown(KeyCode.D) && playerSpeed < maxSpeed) 
		{
			playerSpeed += 1.0f;
		}
		
		float multiplier = (input.average_bpm / maxBPM);
		float targetSpeed = minSpeed + (maxSpeed - minSpeed) * multiplier;
		
		targetSpeed = Mathf.Min(maxSpeed, targetSpeed);

		if(targetSpeed > playerSpeed)
		{
			playerSpeed += (targetSpeed - playerSpeed) * Time.deltaTime * 2;
		}
		else if(targetSpeed < playerSpeed)
		{
			playerSpeed -= (playerSpeed - targetSpeed) * Time.deltaTime * 8;
		}
		
		playerSpeed = minSpeed + (maxSpeed - minSpeed) * multiplier;
	
		newPosition.x += playerSpeed * Time.deltaTime;
		
		// calculating movement to object
		transform.position = newPosition;
		
		road.OffsetSpeed = new Vector2(playerSpeed * Time.deltaTime * 0.001f, 0);
	}
}
