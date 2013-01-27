using UnityEngine;
using System.Collections;

public class grannyMove : MonoBehaviour {
	
	public float enemySpeed = 3.0f;
	public float fallSpeed = 0.1f;
	private bool isDead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 enemyPosition = transform.position;
		enemyPosition.x += -MovingSceneryObject.parallaxSpeedFactor * Time.deltaTime;
		transform.position = enemyPosition;
	
	}
	void OnBecameInvisible() {
		Destroy(this.gameObject);
	}
}
