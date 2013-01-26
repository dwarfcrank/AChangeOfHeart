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
			if (movement.playerSpeed > 0.2f) {
				movement.playerSpeed *= 0.2f;
				movement.multiplier *= 0.5f;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	
}
