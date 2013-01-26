using UnityEngine;
using System.Collections;

public class grannyCollision : MonoBehaviour {
	
	public static int killedGrannies = 0;
	public const int scoreLossPerGranny = 10;
	
	public ParticleSystem explosion;
	
	// Use this for initialization
	void Start () {
	}
	
	public static int GetTotalScoreLoss()
	{
		return killedGrannies * scoreLossPerGranny;
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
			
			killedGrannies++;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
	
}
