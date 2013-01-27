using UnityEngine;
using System.Collections;

public class cloudSpawn : MonoBehaviour {
	
	public Transform prefab;
	Vector3 spawnPoint;
	Vector3 scale;

	
	float spawnTime;
	public static int spawned = 0;
	//public float spawnWait = 3.0f;
	public float spawnDelay = 1.0f;
	int i = 1;
	// Use this for initialization
	void Start () {
		
		StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator Spawn() {
		yield return new WaitForSeconds(spawnDelay);
		do {
			
			spawnPoint = transform.position;
			var t = (Transform)Instantiate(prefab, spawnPoint, Quaternion.Euler(90, 180, 0));
			yield return new WaitForSeconds(1);
			if (i < 2) {
				i++;
			} else {
				i= 1;
			};
		} while (!deathCollision.gameOver);
	}
}
