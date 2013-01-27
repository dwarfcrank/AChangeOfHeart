using UnityEngine;
using System.Collections;

public class grannyCollision : MonoBehaviour {
	
	public int scoreLossPerGranny = 2;
	
	public ParticleSystem explosion;
	
	// Use this for initialization
	void Start () {
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag=="Player")
		{	
			var pos = gameObject.transform.position;
						
			Destroy (gameObject);
			
			var particle = (ParticleSystem)Instantiate (explosion, pos, Quaternion.identity);
			particle.Play ();
			
			var movement = collision.gameObject.GetComponent<Movement>();
			
			movement.playerSpeed = movement.minSpeed;
			
			movement.SubtractScore(scoreLossPerGranny);

			var crash_sound = collision.gameObject.transform.Find("Crash");
			crash_sound.GetComponent<AudioSource>().Play();
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	
}
