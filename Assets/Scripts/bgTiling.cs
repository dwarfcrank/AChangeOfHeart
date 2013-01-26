using UnityEngine;
using System.Collections;

public class bgTiling : MonoBehaviour {
	
	public Transform prefab;
	Vector3 spawnPosition;
	// Use this for initialization
	void Start () {
	
	}

	void OnBecameVisible () {
		
		
		 
		spawnPosition = transform.position;
		spawnPosition.x += 10;
		Instantiate(prefab, spawnPosition, Quaternion.Euler(90, 180, 0));

	}
	void OnBecameInvisible () {
		Destroy (this.gameObject);
	}
}
