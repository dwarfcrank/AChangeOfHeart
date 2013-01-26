using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	int laneNum = 2;
	float laneLocation;
	public static float playerSpeed = 10.2f;
	float horizontal;
	float minSpeed = 1.2f;
	float maxSpeed = 24.0f;
	
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
		Debug.Log (playerSpeed);
		// Changing speed
		if (Input.GetKeyDown(KeyCode.A) && playerSpeed >= minSpeed) 
		{
			playerSpeed += -1.0f;
		}
		else if (Input.GetKeyDown(KeyCode.D) && playerSpeed < maxSpeed) 
		{
			playerSpeed += 1.0f;
		}
		newPosition.x += playerSpeed * Time.deltaTime;
		
		// calculating movement to object
		transform.position = newPosition;
		
	}
}
