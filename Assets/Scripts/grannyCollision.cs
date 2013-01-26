using UnityEngine;
using System.Collections;

public class grannyCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag=="Player")
		{	
			Destroy(this.gameObject);
			
			var movement = collision.gameObject.GetComponent<Movement>();
			
			movement.playerSpeed = movement.minSpeed;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	
}
