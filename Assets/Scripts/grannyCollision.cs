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
				if (Movement.playerSpeed > 0.2f) {
					Movement.playerSpeed += -1.0f;
				}	
			}
		
	}
	// Update is called once per frame
	void Update () {
	
	}
	
}
