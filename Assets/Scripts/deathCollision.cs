using UnityEngine;
using System.Collections;

public class deathCollision : MonoBehaviour {
	
	public GameObject player;
	public static bool gameOver = false;
	
	// Use this for initialization
	void Start () {
		gameOver = false;
	
	}
	void OnCollisionEnter(Collision collision)
	{
		
		if(collision.gameObject.tag=="Player")
		{	
			Destroy(player);
			gameOver = true;
		}
		
	}
	// Update is called once per frame
	void Update () {
	
	}
	
}
