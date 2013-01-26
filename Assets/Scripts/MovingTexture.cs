using UnityEngine;
using System.Collections;

public class MovingTexture : MonoBehaviour {
	
	public Vector2 OffsetSpeed;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var offset = OffsetSpeed * Time.time;
		
		// HACK
		if(deathCollision.gameOver)
		{
			offset = Vector2.zero;
		}
		
		gameObject.renderer.material.mainTextureOffset += offset;
	}
}
