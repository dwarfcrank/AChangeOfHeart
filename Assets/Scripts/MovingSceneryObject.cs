using UnityEngine;
using System.Collections;

public class MovingSceneryObject : MonoBehaviour {
	
	// TODO: Make this make more sense
	public static float parallaxSpeedFactor = 0.4f;
	
	private float speed;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// TODO: Decide a suitable distance and tweak the rest of the constants
		float distance = 10.0f;
		
		speed = (distance - transform.position.z * 2.0f) * parallaxSpeedFactor;
		float translation = -(speed * Time.deltaTime);
		
		transform.Translate(translation, 0.0f, 0.0f);
	}
}
