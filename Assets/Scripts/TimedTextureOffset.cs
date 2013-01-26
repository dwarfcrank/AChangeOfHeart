using UnityEngine;
using System.Collections;

public class TimedTextureOffset : MonoBehaviour {
	
	private float xOffset;
	public float offsetSpeed;
	
	
	// Use this for initialization
	void Start () {
		xOffset = 0;
	}
	
	// Update is called once per frame
	void Update () {
		xOffset -= MovingSceneryObject.parallaxSpeedFactor * offsetSpeed * Time.deltaTime;
		renderer.material.mainTextureOffset = new Vector2 (xOffset, 0.0f);
	}
}
