using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (deathCollision.gameOver) {
			Time.timeScale = 0.0f;
		}
		else {
			Time.timeScale = 1.0f;
		}
	}
}
