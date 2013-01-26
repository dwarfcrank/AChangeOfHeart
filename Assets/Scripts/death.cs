using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {
	
	int laneNum = 2;
	float laneLocation;
	// Use this for initialization
	void Start () {
		StartCoroutine (DeathLane());
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		

		
		
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
		transform.position = newPosition;
	}
	IEnumerator DeathLane() {
		
		do {
			laneNum = Random.Range(0,3);
			yield return new WaitForSeconds(1.0f);
		} while (!deathCollision.gameOver);
	}
}
